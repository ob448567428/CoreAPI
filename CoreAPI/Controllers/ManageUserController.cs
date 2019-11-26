using CoreAPI.Helpers;
using Filters;
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
    public class ManageUserController : ControllerBase
    {
        /// <summary>
        /// 更改密码
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="oldPassword">旧密码</param>
        /// <returns></returns>
        [HttpPost]
        [ActionFilterExtend]
        public ActionResult<bool> ChangePassword(string newPassword, string oldPassword)
        {
            return true;
        }

        /// <summary>
        /// 重置密码
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionFilterExtend]
        public ActionResult<bool> RestPassword()
        {
            return true;
        }


        /// <summary>
        /// 创建用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionFilterExtend]
        public ActionResult<bool> CreateUser()
        {
            return true;
        }

        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ActionFilterExtend]
        public ActionResult<bool> EditUser()
        {
            return true;
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [ActionFilterExtend]
        public ActionResult<bool> DeleteUser()
        {
            return true;
        }
    }
}