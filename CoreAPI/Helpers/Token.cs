using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers
{
    /// <summary>
    /// token base info class
    /// </summary>
    /// <typeparam name="T">more info need to save into memory cache</typeparam>
    public class Token<T> where T : class, new()
    {
        /// <summary>
        /// token key unique
        /// </summary>
        public string TokenKey { get; set; }

        /// <summary>
        /// T means more info for user or others
        /// </summary>
        public T Info { get; set; }
    }
}
