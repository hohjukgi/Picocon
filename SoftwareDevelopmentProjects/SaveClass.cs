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
        /// <param name="Idlist">取得した出欠データ</param>
        public static void ConvertToSaveData(ListView.ListViewItemCollection Idlist)
        {
            exportText = "";
            for(int i = 0; i < Idlist.Count; i++)
            {
                for (int j = 0; j < Idlist[i].SubItems.Count; j++)
                {
                    exportText += Idlist[i].SubItems[j].Text + ",";
                }
                exportText = exportText.Remove(exportText.Length - 1);
                exportText += "\n";
            }
        }

        /// <summary>
        /// 名簿ファイルをもとにcsvファイルを保存する
        /// </summary>
        /// <param name="Idlist">取得した出欠データ</param>
        /// <param name="rosterPath">名簿ファイル</param>
        public static void ConvertToSaveData(ListView.ListViewItemCollection Idlist, string rosterPath)
        {
            string initStr = "";
            MiniFileManager rosterFile = new MiniFileManager(rosterPath);
            string[] rosterString = rosterFile.ReadDataArray(initStr);

            foreach (string roster in rosterString)
            {
                string[] splitedRoster = roster.Split(',');
                foreach (ListViewItem id in Idlist)
                {
                    if (splitedRoster[0] == id.SubItems[0].Text)
                    {
                        exportText += splitedRoster[0] + "," + splitedRoster[1] + "," + id.SubItems[1].Text + "," + id.SubItems[2].Text + "\n";
                    }
                    else
                    {
                        exportText += splitedRoster[0] + "," + splitedRoster[1] + ",-,欠席\n";
                    }
                }
            }
        }

        /// <summary>
        /// exportTextをエンコード形式をしていしてCSV形式に出力
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        /// <param name="encodeMode">エンコード形式</param>
        public static void ExportCsv(string fileName, string encodeMode)
        {
            const string name = "Picocon出席表フォルダ";
            Directory.CreateDirectory(name);
            string[] files = Directory.GetFiles(name);
            foreach (string file in files)
            {
                string cutFileName = file.Replace(name + "\\", "");
                if (cutFileName == "出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv")
                {
                    DialogResult dialogResult =
                        MessageBox.Show("ファイルが上書きされます\r\nいいですか?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(name + "/出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
                , false, System.Text.Encoding.GetEncoding(encodeMode));
            sw.WriteLine(exportText);
            sw.Close();
            LogManager.LogOutput("CSVに出力");
        }

        /// <summary>
        /// exportTextをCSV形式に出力
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public static void ExportCsv(string fileName)
        {
            const string name = "Picocon出席表フォルダ";
            Directory.CreateDirectory(name);
            string[] files = Directory.GetFiles(name);
            foreach (string file in files)
            {
                string cutFileName = file.Replace(name + "\\", "");
                if (cutFileName == "出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv")
                {
                    DialogResult dialogResult =
                        MessageBox.Show("ファイルが上書きされます\r\nいいですか?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(name + "/出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
                , false);
            sw.WriteLine(exportText);
            sw.Close();
            LogManager.LogOutput("CSVに出力");
        }
    }
}
