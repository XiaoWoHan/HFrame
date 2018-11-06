using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace HFrame.Common.Helper
{
    public class LogHelper
    {
        private static Logger logger = LogManager.GetLogger("SimpleDemo");
        public static void Log()
        {
            logger.Error("123");
        }
    }
}
