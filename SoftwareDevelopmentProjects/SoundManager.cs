using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentProjects
{
    public static class SoundManager
    {
        public static int volume = 100;

        public static void PlaySound()
        {
            //オーディオ再生処理
            Random r = new Random();
            int randomValue = r.Next(100);
            if (randomValue == 0)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else if (randomValue == 1)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound2;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else if (randomValue == 2)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound3;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else if (randomValue == 3)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound4;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else if (randomValue == 4)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound5;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else if (randomValue == 5)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound6;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else if (randomValue == 6)
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.lucky_sound7;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
            else
            {
                //オーディオリソースを取り出す
                System.IO.Stream strm = Properties.Resources.Motion_Pop02_1__online_audio_converter_com_;
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                player.Play();
                //後始末
                player.Dispose();
            }
        }
    }
}
