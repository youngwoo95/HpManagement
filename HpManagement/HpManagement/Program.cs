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

            #region Kestrel 서버
            builder.WebHost.UseKestrel((context, options) =>
            {
                options.Configure(context.Configuration.GetSection("Kestrel"));
                options.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                // Keep-Alive TimeOut 3분설정 Keep-Alive 타임아웃: 일반적으로 2~5분, 너무 짧으면 연결이 자주 끊어질 수 있고, 너무 길면 리소스가 낭비될 수 있음.
                options.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(3);

                // 최대 동시 업그레이드 연결 수 : 일반적으로 1000 ~ 5000 사이로 설정하는 것이 좋음.
                // 최대 열린, 업그레이드된 연결 수를  설정한다.
                options.Limits.MaxConcurrentUpgradedConnections = 3000;
                options.Limits.MaxRequestBufferSize = null; // 응답 크기 제한 해제
                options.ConfigureEndpointDefaults(endpointOptions =>
                {
                    // 프로토콜 설정: HTTP/1.1과 HTTP/2를 모두 지원하는 것을 권장.
                    // HTTP/2는 성능 향상과 효율적인 데이터 전송을 제공함.
                    endpointOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                });

                options.Listen(IPAddress.Any, 5445, listenOptions =>
                {
                    listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
                });
            });
            #endregion

            // 전달될 헤더의 미들웨어 순서
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
                    // 전역 정책: S-TEC API 호출시
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
            // 1) Configuration에서 커넥션 문자열 읽기
            var mariaConnStr = builder.Configuration.GetSection("ConnectionStrings:MySqlConnection").Get<string>();

            // 2) IDbConnection을 Scoped 서비스로 등록
            builder.Services.AddScoped<IDbConnection>(sp =>
                new MySqlConnection(mariaConnStr)
            );
            #endregion

            #region 캐쉬 사용
            /* 메모리 캐시 등록 */
            //builder.Services.AddMemoryCache();
            #endregion
            #region Redis 분산 캐쉬 사용
            builder.Services.AddStackExchangeRedisCache(options =>
            {
                var redisCfg = builder.Configuration.GetSection("Redis");
                options.Configuration = redisCfg["Configuration"]!;
                options.InstanceName = redisCfg["InstanceName"]!;
            });
            #endregion


            #region JWT Token
            // JWTToken 기본 매핑 제거
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
                        // Authorization 헤더가 "Bearer " 접두어 없이 단순 토큰일 경우 처리
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
                c.EnableAnnotations(); // SwaggerResponse 어트리뷰트 사용 (옵션)
                //c.ExampleFilters(); // SwaggerResponse 어트리뷰트 사용
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "병동관리 시스템",
                    Description = "에스텍시스템 삼성병원 병동관리 시스템"
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

            #region 역방향 프록시 서버 사용
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            #endregion

            #region 응답압축 미들웨어 추가
            app.UseResponseCompression();
            #endregion

            #region 디버깅 모드일시 스웨거 사용
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            #endregion

            #region MIME 타입 및 압축헤더 설정
            /*
                MIME 타입 및 압축 헤더 설정
                기본 제공되지 않는 MIME 타입 추가.
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
                    /* 압축된 파일에 대한 Content-Encoding 헤더 설정 */
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
            
            #region CORS 미들웨어 적용
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
