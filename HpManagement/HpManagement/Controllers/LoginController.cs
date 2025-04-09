using HpManagement.DTO;
using HpManagement.Services.Logger;
using HpManagement.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace HpManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoggerService LoggerService;
        private readonly ILoginService LoginService;

        public LoginController(ILoggerService _loggerservice,
            ILoginService _loginservice)
        {
            this.LoggerService = _loggerservice;
            this.LoginService = _loginservice;
        }

        /// <summary>
        /// [웹] 로그인
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/WebLogin")]
        [Produces("application/json")]
        public async Task<IActionResult> WebLogin([FromBody]LoginDTO dto)
        {
            try
            {
                var model = await LoginService.WebLoginService(dto);

                if (model is null)
                    return BadRequest();

                if (model.code == 200)
                    return Ok(model);
                else if (model.code == 204)
                    return NoContent();
                else
                    return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
        }

        /// <summary>
        /// [웹] 토큰 재발급
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/WebRefreshLogin")]
        [Produces("application/json")]
        public async Task<IActionResult> WebRefreshLogin([FromBody]RefreshTokenDTO dto)
        {
            try
            {
                var model = await LoginService.WebLoginRefreshTokenService(dto);
                if (model is null)
                    return BadRequest();

                if (model.code == 200)
                    return Ok(model);
                else if (model.code == 204)
                    return NoContent();
                else if (model.code == 401)
                    return Unauthorized();
                else
                    return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
        }

        /// <summary>
        /// [모바일] 로그인
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/MobileLogin")]
        [Produces("application/json")]
        public async Task<IActionResult> MobileLogin([FromBody]LoginDTO dto)
        {
            try
            {
                var model = await LoginService.MobileLoginService(dto);

                if (model is null)
                    return BadRequest();

                if (model.code == 200)
                    return Ok(model);
                else if (model.code == 204)
                    return NoContent();
                else
                    return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
        }

        /// <summary>
        /// [모바일] 토큰 재발급
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("v1/MobileRefreshLogin")]
        [Produces("application/json")]
        public async Task<IActionResult> MobileRefreshLogin([FromBody]RefreshTokenDTO dto)
        {
            try
            {
                var model = await LoginService.MobileRefreshTokenService(dto);

                if (model is null)
                    return BadRequest();

                if (model.code == 200)
                    return Ok(model);
                else if (model.code == 204)
                    return NoContent();
                else if (model.code == 401)
                    return Unauthorized();
                else
                    return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
            catch(Exception ex)
            {
                LoggerService.LogMessage(ex.ToString());
                return Problem("서버에서 처리할 수 없는 요청입니다.", statusCode: 500);
            }
        }


    }
}
