using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoreAPI.Helpers;
using Filters;
using Helpers;
using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
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
        /// 登录
        /// </summary>
        /// <param name="str">传入参数</param>
        /// <returns></returns>
        [HttpPost]
        [ActionFilterExtend(FunCode = "001")]
        //[AllowAnonymous]
        public ActionResult<OutputModel<string>> Login([FromBody] string str)
        {
            var input = new LoginInput();
            var tuple = _loginService.Login(input);
            if (tuple.Item1)
            {
                //todo:将员工基本信息写入内存中 tuple.Item2
                return new OutputModel<string>() { StatusCode = (int)HttpStatusCode.OK, IsSuccess = true, Message = "登陆成功", Data = "" };
            }
            else
            {
                return new OutputModel<string>() { StatusCode = (int)HttpStatusCode.BadRequest, IsSuccess = false, Message = "登陆失败，账户或密码错误", Data = "" };
            }
        }
        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="key">传入参数key</param>
        /// <returns></returns>
        [HttpPost]
        [ActionFilterExtend(FunCode ="002")]
        public ActionResult<OutputModel<string>> Logout([FromQuery] string key)
        {
            var memoryCacheInstance = MemoryCacheSingleton.GetMemoryCacheInstance();
            if (memoryCacheInstance.Remove(key))
            {
                return new OutputModel<string>() { StatusCode = (int)HttpStatusCode.OK, IsSuccess = true, Message = "退出成功", Data = "" };
            }
            else
            {
                return new OutputModel<string>() { StatusCode = (int)HttpStatusCode.BadRequest, IsSuccess = false, Message = "退出失败", Data = "" };
            }
        }
    }
}