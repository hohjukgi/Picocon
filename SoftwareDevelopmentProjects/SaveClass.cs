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

            //確認用メッセージボックス
            //MessageBox.Show(exportText);
        }

        /// <summary>
        /// 名簿ファイルをもとにcsvファイルを保存する
        /// </summary>
        /// <param name="Idlist">取得した出欠データ</param>
        /// <param name="rosterPath">名簿ファイル</param>
        public static void ConvertToSaveData(ListView.ListViewItemCollection Idlist, string rosterPath)
        {

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
                if (cutFileName == "出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx")
                {
                    DialogResult dialogResult =
                        MessageBox.Show("ファイルが上書きされます\r\nいいですか?", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if(dialogResult == DialogResult.Cancel)
                    {
                        return;
                    }
                }
            }
            StreamWriter sw = new StreamWriter(name + "/出席表_" + fileName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
            sw.WriteLine(exportText);
            sw.Close();
            LogManager.LogOutput("CSVに出力");
        }
    }
}
