using HpManagement.Repository.Login;
using HpManagement.Services.Logger;
using HpManagement.Services.Login;
using HpManagement.Services.Redis;
using HpManagement.Services.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Swashbuckle.AspNetCore.Filters;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;

namespace HpManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Kestrel ����
            builder.WebHost.UseKestrel((context, options) =>
            {
                options.Configure(context.Configuration.GetSection("Kestrel"));
                options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                // Keep-Alive TimeOut 3�м��� Keep-Alive Ÿ�Ӿƿ�: �Ϲ������� 2~5��, �ʹ� ª���� ������ ���� ������ �� �ְ�, �ʹ� ��� ���ҽ��� ����� �� ����.
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3);

                // �ִ� ���� ���׷��̵� ���� �� : �Ϲ������� 1000 ~ 5000 ���̷� �����ϴ� ���� ����.
                // �ִ� ����, ���׷��̵�� ���� ����  �����Ѵ�.
                options.Limits.MaxConcurrentUpgradedConnections = 3000;
                options.Limits.MaxRequestBufferSize = null; // ���� ũ�� ���� ����
                options.ConfigureEndpointDefaults(endpointOptions =>
                {
                    // �������� ����: HTTP/1.1�� HTTP/2�� ��� �����ϴ� ���� ����.
                    // HTTP/2�� ���� ���� ȿ������ ������ ������ ������.
                    endpointOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                });

                options.Listen(IPAddress.Any, 5445, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                });
            });
            #endregion

            // ���޵� ����� �̵���� ����
            builder.Services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

            builder.Services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes =
                    ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });

            #region CORS
            var AllowCors = "AllowIp";
            string[]? CorsArr = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            if (CorsArr is [_, ..])
            {

                builder.Services.AddCors(options =>
                {
                    // ���� ��å: S-TEC API ȣ���
                    options.AddPolicy(name: AllowCors, builder =>
                    {
                        builder.WithOrigins(CorsArr)
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
                });
            }
            else
            {
                throw new InvalidOperationException("'Cors' is null or empty");
            }
            #endregion

            #region MariaDB
            // 1) Configuration���� Ŀ�ؼ� ���ڿ� �б�
            var mariaConnStr = builder.Configuration.GetSection("ConnectionStrings:MySqlConnection").Get<string>();

            // 2) IDbConnection�� Scoped ���񽺷� ���
            builder.Services.AddScoped<IDbConnection>(sp =>
                new MySqlConnection(mariaConnStr)
            );
            #endregion

            #region ĳ�� ���
            /* �޸� ĳ�� ��� */
            //builder.Services.AddMemoryCache();
            #endregion
            #region Redis �л� ĳ�� ���
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                var redisCfg = builder.Configuration.GetSection("Redis");
                options.Configuration = redisCfg["Configuration"]!;
                options.InstanceName = redisCfg["InstanceName"]!;
            });
            #endregion


            #region JWT Token
            // JWTToken �⺻ ���� ����
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:authSigningKey"]!)),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    RoleClaimType = "Role",
                    ClockSkew = TimeSpan.Zero
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        // Authorization ����� "Bearer " ���ξ� ���� �ܼ� ��ū�� ��� ó��
                        var authHeader = context.Request.Headers["Authorization"].ToString();
                        if (!string.IsNullOrEmpty(authHeader) && !authHeader.StartsWith("Bearer "))
                        {
                            context.Token = authHeader;
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion


#if DEBUG
            builder.Services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations(); // SwaggerResponse ��Ʈ����Ʈ ��� (�ɼ�)
                //c.ExampleFilters(); // SwaggerResponse ��Ʈ����Ʈ ���
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "�������� �ý���",
                    Description = "�����ؽý��� �Ｚ���� �������� �ý���"
                });
            });
#endif

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            #region DI
            builder.Services.AddTransient<ILoggerService, LoggerService>();
            builder.Services.AddTransient<ITokenComm, TokenComm>();

            builder.Services.AddScoped<ILoginRepository, LoginRepository>();


            builder.Services.AddScoped<ILoginService, LoginService>();
            builder.Services.AddScoped<IRedisCacheService, RedisCacheService>();
            #endregion

            builder.Services.AddControllers();

            var app = builder.Build();

            #region ������ ���Ͻ� ���� ���
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion

            #region ������� �̵���� �߰�
            app.UseResponseCompression();
            #endregion

            #region ����� ����Ͻ� ������ ���
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #endregion

            #region MIME Ÿ�� �� ������� ����
            /*
                MIME Ÿ�� �� ���� ��� ����
                �⺻ �������� �ʴ� MIME Ÿ�� �߰�.
             */
            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings =
                    {
                        [".wasm"] = "application/wasm",
                        [".gz"] = "application/octet-stream",
                        [".br"] = "application/octet-stream",
                        [".jpg"] = "image/jpg",
                        [".jpeg"] ="image/jpeg",
                        [".png"] = "image/png",
                        [".gif"] = "image/gif",
                        [".webp"] = "image/webp",
                        [".xlsx"] = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        [".pdf"] = "application/pdf"
                    }
                },
                OnPrepareResponse = ctx =>
                {
                    /* ����� ���Ͽ� ���� Content-Encoding ��� ���� */
                    if (ctx.File.Name.EndsWith(".gz"))
                    {
                        ctx.Context.Response.Headers["Content-Encoding"] = "gzip";
                    }
                    else if (ctx.File.Name.EndsWith(".br"))
                    {
                        ctx.Context.Response.Headers["Content-Encoding"] = "br";
                    }
                }
            });

            #endregion

            //app.UseHttpsRedirection();
            
            #region CORS �̵���� ����
            app.UseCors("AllowIp");
            #endregion


            string[]? ApiMiddleWare = new string[]
            {
                //"/api/Login/sign",
                //"/api/Store/sign",
                //"/api/DashBoard/sign",
                //"/api/Country/sign"
            };

            foreach (var path in ApiMiddleWare)
            {
                app.UseWhen(context => context.Request.Path.StartsWithSegments(path), appBuilder =>
                {
                    appBuilder.UseMiddleware<TokenMiddleWare>();
                });
            }

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}
