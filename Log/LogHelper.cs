using log4net;
using System;

namespace Log
{
    
    public class LogHelper
    {       
        private static ILog log = LogManager.GetLogger("", "");
        public static void Debug(string msg)
        {
            log.Debug(msg);
        }
        public static void Info(string msg)
        {
            log.Info(msg);
        }
        public static void Warn(string msg)
        {
            log.Warn(msg);
        }
        public static void Error(string msg)
        {
            log.Error(msg);
        }
        public static void Fatal(string msg)
        {
            log.Fatal(msg);
        }

    }
}
