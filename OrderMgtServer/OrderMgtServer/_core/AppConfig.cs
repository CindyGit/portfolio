using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace OrderMgtServer._core
{
    public class AppConfig
    {
        #region 私有變數
        private static string _DBConnStr;
        #endregion
        #region 建構子
        static AppConfig()
        {
            _DBConnStr = ReadConnectionString("DBConnStr");
        }
        #endregion
        #region 私有函式

        private static string ReadConfigString(string keyName)
        {
            string retStr = WebConfigurationManager.AppSettings[keyName];
            if (retStr == null)
            {
                throw new Exception("Unable to read app settings. Please check appsetting section in Web.config file.(" + keyName + ")");
            }
            return retStr;
        }
        private static string ReadConnectionString(string keyName)
        {
            string retStr = WebConfigurationManager.ConnectionStrings[keyName].ToString();
            if (retStr == null)
            {
                throw new Exception("Unable to read app settings. Please check appsetting section in Web.config file.(" + keyName + ")");
            }
            return retStr;
        }

        #endregion
        #region 公用屬性
        /// <summary>
        /// DBConnStr 資料庫連線資訊
        /// </summary>
        public static string DBConnStr
        {
            get { return _DBConnStr; }
        }

        #endregion
    }
}