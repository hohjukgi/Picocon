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
            for(int i = 0; i < Idlist.Count; i++)
            {

            }
        }

        /// <summary>
        /// exportTextをCSV形式に出力
        /// </summary>
        public static void ExportCsv()
        {
            StreamWriter sw = new StreamWriter("test.csv");
            sw.WriteLine(exportText);
            sw.Close();
        }
    }
}
