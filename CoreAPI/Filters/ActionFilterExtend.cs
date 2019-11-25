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

    /// <summary>
    /// 
    /// </summary>
    public class ExceptionFilterExtend : IExceptionFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void OnException(ExceptionContext context)
        {
            // 日志入库
            //向负责人发报警邮件，异步
            //向负责人发送报警短信或者报警电话，异步

            Exception ex = context.Exception;
            //这里获取服务器ip时，需要考虑如果是使用nginx做了负载，这里要兼容负载后的ip，
            //监控了ip方便定位到底是那台服务器出故障了
            //string ip = context.HttpContext.Connection.RemoteIpAddress.ToString();

            LogHelper.Error($"堆栈信息：{ex.StackTrace},异常描述：{ex.Message}");
            context.Result = new JsonResult(new OutputModel<string> { StatusCode = (int)HttpStatusCode.InternalServerError, IsSuccess = false, Message = "内部错误", Data = "" });
            context.ExceptionHandled = true;
        }
    }
}
