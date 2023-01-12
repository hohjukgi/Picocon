using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareDevelopmentProjects
{
    /// <summary>
    /// 遅刻判断用クラス
    /// </summary>
    public static class LateClass
    {

        /// <summary>
        /// 遅刻の状態に応じて文字列を返す
        /// </summary>
        /// <param name="timeStart">講義開始時間</param>
        /// <param name="timeNow">現在時刻</param>
        /// <param name="postponement">猶予</param>
        /// <returns>文字列</returns>
        public static string LateJudge(DateTime timeStart, DateTime timeNow, TimeSpan postponement)
        {
            if (postponement < timeNow - timeStart)
            {
                return "無効";
            }
            else if (TimeSpan.Parse("0:0:0") < timeNow - timeStart)
            {
                return "遅刻";
            }
            return "正常";
        }
    }
}
