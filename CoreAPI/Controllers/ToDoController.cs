using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace CoreAPI.Controllers
{
    /// <summary>
    /// ToDoController
    /// </summary>   
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
            
        /// <summary>
        /// 获取测试
        /// </summary>
        /// <param name="str">传入参数</param>
        /// <param name="str1">传入参数1</param>
        /// <returns></returns>
        [HttpGet]
        //[ActionFilterExtend]
        public ActionResult<string> GetTest([FromQuery] string str, string str1)
        {
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

        /// <summary>
        /// post测试
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> PostTest(string str, string str1)
        {
            return "PostTest";
        }
        /// <summary>
        /// PutTest
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<string> PutTest()
        {
            return "PutTest";
        }
        /// <summary>
        /// DeleteTest
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<string> DeleteTest()
        {
            return "DeleteTest";
        }
    }
}