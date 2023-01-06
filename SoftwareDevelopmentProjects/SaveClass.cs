using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareDevelopmentProjects
{
    public static class SaveClass
    {
        //変換した適す値
        private static string exportText;

        /// <summary>
        /// 保存してあるデータをexportTextにまとめる
        /// </summary>
        public static void ConvertToSaveData(ListView.ListViewItemCollection Idlist)
        {
            exportText = "";
            for(int i = 0; i < Idlist.Count; i++)
            {
                exportText += Idlist[i].SubItems[0].Text + "," + Idlist[i].SubItems[1].Text +"\n";
            }

            //確認用メッセージボックス
            //MessageBox.Show(exportText);
        }

        /// <summary>
        /// exportTextをCSV形式に出力
        /// </summary>
        public static void ExportCsv(string fileName)
        {
            const string name = "Picocon出席表フォルダ";
            Directory.CreateDirectory(name);
            string[] files = Directory.GetFiles(name);
            foreach(string file in files)
            {
                string cutFileName = file.Replace(name + "\\", "");
                if (cutFileName == "出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv")
                {
                    DialogResult dialogResult =
                        MessageBox.Show("ファイルが上書きされます\r\nいいですか?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(name + "/出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv");
            sw.WriteLine(exportText);
            sw.Close();
            LogManager.LogOutput("CSVに出力");
        }
    }
}
