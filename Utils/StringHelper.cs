using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Utils
{
    public static class StringHelper
    {
        public static readonly Regex EmailRegex = new Regex("^([a-zA-Z0-9][_\\.\\-]*)+\\@([A-Za-z0-9])+((\\.|-|_)[A-Za-z0-9]+)*((\\.[A-Za-z0-9]{2,15}){1,2})$", RegexOptions.Compiled);

        private static readonly Regex RegTel = new Regex("^(\\d{2,4}[-_－—]?)?\\d{3,8}([-_－—]?\\d{3,8})?([-_－—]?\\d{1,7})?$", RegexOptions.Compiled);

        private static readonly Regex RegMobile = new Regex("^((\\(\\d{2,3}\\))|(\\d{3}\\-))?1[3|5|4|8|7]\\d{9}$", RegexOptions.Compiled);

        private static DateTime _TempDate;

        public static bool IsChinese(string inputData)
        {
            return new Regex("[一-龥]+").Match(inputData).Success;
        }

        public static bool ValidatorStr(string inputData)
        {
            return inputData.Length <= 0 || new Regex("^[^<>'=&*,]+$").Match(inputData).Success;
        }

        public static bool IsUrl(string inputData)
        {
            return new Regex("^http://([w-]+.)+[w-]+(/[w-./ %&=]*)$").Match(inputData).Success;
        }

        public static bool IsQQ(string inputData)
        {
            return new Regex("^[1-9]*[1-9][0-9]*$").Match(inputData).Success;
        }

        public static bool IsIDCard(string inputData)
        {
            return new Regex("(^[1-9]\\d{5}[1-9]\\d{3}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])((\\d{4})|\\d{3}[A-Z])$)|(^[1-9]\\d{7}((0\\d)|(1[0-2]))(([0|1|2]\\d)|3[0-1])\\d{3}$)").Match(inputData).Success;
        }

        public static bool IsUserName(string inputData)
        {
            return new Regex("^[a-zA-Z]\\w{5,15}$").Match(inputData).Success;
        }

        public static bool IsEnglish(string inputData)
        {
            return new Regex("^[A-Za-z]+$").Match(inputData).Success;
        }

        public static bool IsTrimRow(string inputData)
        {
            return new Regex("\\n[\\s| ]*\\r").Match(inputData).Success;
        }

        public static bool IsNumber(string inputData)
        {
            return new Regex("^[0-9]+$").Match(inputData).Success;
        }

        public static bool IsNumberSign(string inputData)
        {
            return new Regex("^[+-]?[0-9]+$").Match(inputData).Success;
        }

        public static bool IsDecimal(string inputData)
        {
            return new Regex("^[0-9]+[.]?[0-9]+$").Match(inputData).Success;
        }

        public static bool IsDecimalSign(string inputData)
        {
            return new Regex("^[+-]?[0-9]+[.]?[0-9]+$").Match(inputData).Success;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            email = email.Trim();
            return StringHelper.EmailRegex.IsMatch(email);
        }

        public static bool IsEmail(string email)
        {
            return StringHelper.IsValidEmail(email);
        }

        public static bool IsRealEmail(string email)
        {
            return StringHelper.IsValidEmail(email);
        }

        public static bool IsTel(string inputData)
        {
            return StringHelper.RegTel.Match(inputData).Success;
        }

        public static bool IsMobile(string inputData)
        {
            return StringHelper.RegMobile.Match(inputData).Success;
        }

        public static bool IsDate(string inputData)
        {
            return DateTime.TryParse(inputData, out StringHelper._TempDate);
        }

        /// <summary>
        /// 是否获取13位时间戳
        /// </summary>
        /// <param name="is_13"></param>
        /// <returns></returns>
        public static string GetTimeStamp(bool is_13)
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var val = is_13 ? ts.TotalMilliseconds : ts.TotalSeconds;
            return Convert.ToInt64(val).ToString();
        }
    }
}
