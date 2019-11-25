using CoreAPI.Helpers;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Net;
using System.Threading.Tasks;
using Utils;


namespace Filters
{
    /// <summary>
    /// action filter extend
    /// </summary>
    public class ActionFilterExtend : ActionFilterAttribute
    {
        /// <summary>
        /// run this function before controller action run
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var headers = context.HttpContext.Request.Headers;
            string key = "";
            if (headers != null && headers.ContainsKey("Authorization"))
            {
                key = headers["Authorization"].ToString().Split(' ')[0];
            }

            var memoryCacheInstance = MemoryCacheSingleton.GetMemoryCacheInstance();
            //get old memoryCache value by key
            var oldToken = memoryCacheInstance.GetT<Token<BaseInfo>>(key);
            if (oldToken == null)
            {
                //throw new Exception("无权限");
                context.Result = new JsonResult(new OutputModel<string> { StatusCode = (int)HttpStatusCode.Forbidden, IsSuccess = false, Message = "无权限，访问被拒绝", Data = null });
            }
            else
            {
                var token = new Token<BaseInfo>()
                {
                    TokenKey = key,
                    Info = new BaseInfo()
                };
                memoryCacheInstance.RefreshMemoeyCache(token, token.TokenKey);
            }
            base.OnActionExecuting(context);
        }
        /// <summary>
        ///  run this function after controller action run。
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
        /// <summary>
        /// run this function after controller action run。Even it is later than OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            return base.OnResultExecutionAsync(context, next);
        }
    }
}
