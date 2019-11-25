using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Utils
{
    public static class CryptoHelper
    {
        public static string MD5Encrypt32(string str, Encoding encode)
        {
            //密文
            string en_str = string.Empty;
            //实例化一个md5对像
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(encode.GetBytes(str));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            StringBuilder tmp = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。
                //格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符
                //X2表示16进制
                tmp.Append(i.ToString("x2"));
            }
            return tmp.ToString();
        }
    }
}
