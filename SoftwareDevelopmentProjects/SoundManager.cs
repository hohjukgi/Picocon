using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDevelopmentProjects
{
    public static class SoundManager
    {
        public static void PlaySound()
        {
            //オーディオ再生処理
            Task task = Task.Run(() =>
            {
                Random r = new Random();
                int randomValue = r.Next(100);
                if (randomValue == 0)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else if (randomValue == 1)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound2;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else if (randomValue == 2)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound3;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else if (randomValue == 3)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound4;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else if (randomValue == 4)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound5;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else if (randomValue == 5)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound6;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else if (randomValue == 6)
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.lucky_sound7;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
                else
                {
                    //オーディオリソースを取り出す
                    System.IO.Stream strm = Properties.Resources.Motion_Pop02_1__online_audio_converter_com_;
                    //同期再生する
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                    player.PlaySync();
                    //後始末
                    player.Dispose();
                }
            });
        }
    }
}
