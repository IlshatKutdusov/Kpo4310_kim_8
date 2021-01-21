using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kpo4310.Utility;
using Kpo4310.kim.Lib;

namespace Kpo4310.Lib
{
    public static class AppGlobalSettings
    {
        private static string _logPath;
        private static string _dataFileName;
        private static string _mode;

        public static string logPath
        { get => _logPath; }

        public static string dataFileName
        { get => _dataFileName; }

        public static string mode
        { get => _mode; }

        public static void Initialize()
        {
            AppConfigUtility appConfigUtitlity = new AppConfigUtility();
            _logPath = appConfigUtitlity.AppSettings("logPath");
            _dataFileName = appConfigUtitlity.AppSettings("dataFileName");
            _mode = appConfigUtitlity.AppSettings("mode");
        }
    }
}
