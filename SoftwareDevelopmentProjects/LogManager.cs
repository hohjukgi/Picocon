using System;
using System.IO;
using System.Windows.Forms;

namespace SoftwareDevelopmentProjects
{
    public static class LogManager
    {
        /// <summary>
        /// ログを出力するテキストボックス
        /// </summary>
        public static TextBox logTextBox;

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
            logTextBox.Text = msg;
        }
    }
}
