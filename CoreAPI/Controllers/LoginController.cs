using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Login;
using Utils;

namespace CoreAPI.Controllers
{
    /// <summary>
    /// controller for login
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        /// <summary>
        /// Constructor Injection ILoginService
        /// </summary>
        /// <param name="loginService"></param>
        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        /// <summary>
        /// 获取测试
        /// </summary>
        /// <param name="str">传入参数</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Login([FromBody] string str)
        {
            Convert.ToInt32("aaaa");
            _loginService.Login();
            LogHelper.Error("123123");
            LogHelper.Info("123123");
            LogHelper.Debug("123123");
            return "GetTest";
        }
        /// <summary>
        /// 获取测试
        /// </summary>
        /// <param name="str">传入参数</param>
        /// <param name="str1">传入参数1</param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<string> GetTest1([FromQuery] string str, string str1)
        {
            return "GetTest1";
        }
    }
}