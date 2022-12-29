using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareDevelopmentProjects
{
    /// <summary>
    /// 音声再生用クラス
    /// </summary>
    public static class SoundManager
    {
        //乱数用
        private static Random r = new Random();

        private static readonly Stream[] defaultSounds = {
            Properties.Resources.lucky_sound,
            Properties.Resources.lucky_sound2,
            Properties.Resources.lucky_sound3,
            Properties.Resources.lucky_sound4,
            Properties.Resources.lucky_sound5,
            Properties.Resources.lucky_sound6,
            Properties.Resources.lucky_sound7
        };

        /// <summary>
        /// 音声を再生する
        /// </summary>
        /// <returns>乱数値</returns>
        public static int PlaySound()
        {
            //オーディオ再生処理
            int randomValue = r.Next(100);

            //音声ストリーム
            Stream strm;

            switch (randomValue)
            {
                case 0:
                    strm = defaultSounds[0];
                    break;

                case 1:
                    strm = defaultSounds[1];
                    break;

                case 2:
                    strm = defaultSounds[2];
                    break;

                case 3:
                    strm = defaultSounds[3];
                    break;

                case 4:
                    strm = defaultSounds[4];
                    break;

                case 5:
                    strm = defaultSounds[5];
                    break;

                case 6:
                    strm = defaultSounds[6];
                    break;

                default:
                    strm = Properties.Resources.Motion_Pop02_1__online_audio_converter_com_;
                    break;
            }

            //サウンドプレイヤの初期化
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);

            //再生
            player.Play();
            //後始末
            player.Dispose();
            
            return randomValue;
        }
    }
}
