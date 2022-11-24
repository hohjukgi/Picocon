using System;
using System.IO;

namespace SoftwareDevelopmentProjects
{
    public static class LogManager
    {

        /// <summary>
        /// ログを出力する
        /// </summary>
        /// <param name="msg">メッセージ</param>
        public static void LogOutput(string msg)
        {
            using(StreamWriter sw = new StreamWriter("log.txt", true))
            {
                sw.WriteLine("[" + DateTime.Now.ToString("G") + "] " + msg);
            }
        }
    }
}
