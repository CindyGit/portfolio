using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace OrderMgtServer._core
{
    public class Common
    {
        public static void WriteLogFile(string Message)
        {
            try
            {
                string path = System.AppDomain.CurrentDomain.BaseDirectory + "Log\\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string LogFile = Path.Combine(path, "PersonalitySrv" + DateTime.Now.ToString("yyyyMMdd") + ".log");

                if (!File.Exists(LogFile))
                {
                    FileStream fs = File.Create(LogFile);//建立
                    fs.Close();
                }

                File.AppendAllText(LogFile, string.Format("[{0}]", DateTime.Now.ToString()));
                File.AppendAllText(LogFile, Message + "|\r\n");
            }
            catch (Exception ex)
            {

            }
        }

        public static string GetSessionValue(string name)
        {
            if (HttpContext.Current.Session == null)
            {
                return string.Empty;
            }
            else
            {
                return Convert.ToString(HttpContext.Current.Session[name]);
            }
        }

        public static void SetSessionValue(string name, string value)
        {
            if (HttpContext.Current.Session == null)
            {
                return;
            }
            else
            {
                HttpContext.Current.Session[name] = value;
            }
        }

    }
}