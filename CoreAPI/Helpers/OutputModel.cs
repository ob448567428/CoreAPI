using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Helpers
{
    /// <summary>
    /// 输出数据结构
    /// </summary>
    public class OutputModel<T>
    {
        /// <summary>
        /// 状态值
        /// </summary>
        public int StatusCode { get; set; } = 200;
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess { get; set; } = true;
        /// <summary>
        /// 提示信息
        /// </summary>
        public string Message { get; set; } = "";
        /// <summary>
        /// 返回数据
        /// </summary>

        public T Data { get; set; }
    }
}
