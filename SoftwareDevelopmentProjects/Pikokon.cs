using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FelicaLib;

namespace SoftwareDevelopmentProjects
{
    public partial class Pikokon : Form
    {

        private bool ready = false;                 //初期化が完了したかどうか
        private MiniFileManager cameraIndex;        //カメラ番号ファイルの操作クラス

        public Pikokon()
        {
            InitializeComponent();

            //時間更新タイマーを起動
            dateTimer.Start();

            //ログ出力に使用するテキストボックスを指定
            LogManager.logTextBox = logText;
            
            //表示用リスト初期化
            listStudentId.View = View.Details;
            listStudentId.GridLines = true;

            //系列追加
            listStudentId.Columns.Add("学籍番号", 100, HorizontalAlignment.Left);
            listStudentId.Columns.Add("出席時刻", 100, HorizontalAlignment.Left);

            /*
            //リストに画像を表示するための設定
            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(1, 30);
            listStudentId.SmallImageList = imageListSmall;
            */

            //カメラ番号を保存するクラスの初期化
            cameraIndex = new MiniFileManager("cameraSettings.pico");

            //カメラ番号を保存するクラスから読み取った数値をカメラ番号に設定
            upDownCamera.Value = int.Parse(cameraIndex.ReadData("0"));

            //初期化終了
            ready = true;
        }

        /// <summary>
        /// 学籍番号読み取り開始ボタンの切り替え
        /// </summary>
        private void ToggleFelica()
        {
            //学生証読み取り開始
            fericaLoadTimer.Enabled = !fericaLoadTimer.Enabled;

            //ボタンText変更
            if (buttonRead.Text == "開始")
            {
                //例外発生防止のため、ボタン操作を停止する
                buttonRead.Enabled = false;
                buttonRead.Text = "停止";
                LogManager.LogOutput("学籍番号の取得開始");
            }
            else
            {
                buttonRead.Enabled = true;
                buttonRead.Text = "開始";
                LogManager.LogOutput("学籍番号の取得停止");
            }
        }

        /// <summary>
        /// 学生証読み取りの切り替え
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ToggleFelica();
            /*

                    //カラムを追加


                    string[] row1 = { "XXX", "愛知太郎", "XXXX"};

                    //リスト項目を追加
                    listView1.Items.Add(new ListViewItem(row1));
                    DateTime nowdt = DateTime.Now;
                    textBox1.Text = nowdt.ToString();
            */

        }

        /// <summary>
        /// 日時更新用タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;

            //時間ラベルを更新する
            labelTime.Text = datetime.ToString("MM月dd日\nHH:mm:ss");
        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// 削除ボタンの有効化設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //項目数が0より多いなら
            if(listStudentId.SelectedItems.Count > 0)
            {
                //削除ボタンを有効化
                buttonDelete.Enabled = true;
            }
            else
            {
                //削除ボタンの無効化
                buttonDelete.Enabled = false;
            }
        }

        //リスト項目の削除
        private void button3_Click(object sender, EventArgs e)
        {
            if (listStudentId.SelectedItems.Count > 0)
            {
                //指定した学籍番号をリストから削除
                listStudentId.Items.Remove(listStudentId.SelectedItems[0]);
                LogManager.LogOutput("選択した項目を削除");
            }
        }

        private void Pikokon_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 学生証読み取りタイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fericaLoadTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                using (Felica f = new Felica())
                {
                    try
                    {
                        //学生証を読み取り
                        string str = FericaFunc.readStudentId(f);
                        if (str == "00000000")
                        {
                            //稀に発生する00000000の学籍番号
                            LogManager.LogOutput("00000000の学籍番号を取得");
                            return;
                        }
                        for (int i = 0; i < listStudentId.Items.Count; i++)
                        {
                            if (listStudentId.Items[i].SubItems[0].Text == str)
                            {
                                //同名の学籍番号
                                LogManager.LogOutput("重複する学籍番号を取得");
                                return;
                            }
                        }

                        //ズル防止にチェックが入っていたら
                        if (checkBoxDetectFace.Checked)
                        {
                            //画像処理用クラスを生成
                            CameraClass camera = new CameraClass();
                            //カメラから写真を撮る
                            camera.TakePhoto((int)upDownCamera.Value);
                            //顔が検知できなかったら
                            if (camera.DetectFace() == false)
                            {
                                return;
                            }
                        }
                        

                        //オーディオ再生処理
                        Task task = Task.Run(() =>
                        {
                        //オーディオリソースを取り出す
                        System.IO.Stream strm = Properties.Resources.Motion_Pop02_1__online_audio_converter_com_;
                        //同期再生する
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                            player.PlaySync();
                        //後始末
                        player.Dispose();
                        });

                        //時間を取得
                        DateTime dateTime = DateTime.Now;

                        //リスト項目に追加
                        string[] row = { str, dateTime.ToString("t") };
                        listStudentId.Items.Add(new ListViewItem(row));

                        LogManager.LogOutput("学籍番号を取得: " + str);
                    }
                    catch (Exception)//学生証を読み取れなかった場合など
                    {
                        //ボタンの追操作を許可
                        buttonRead.Enabled = true;
                    }
                }
            } 
            catch (Exception ex)//重大な例外
            {
                //読み取りを停止する
                ToggleFelica();
                LogManager.LogOutput(ex.Message);
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }

        /// <summary>
        /// 保存ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //データを保存しやすいように変換
            SaveClass.ConvertToSaveData(listStudentId.Items);
            //保存
            SaveClass.ExportCsv();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// カメラテストボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                //カメラを初期化
                CameraClass camera = new CameraClass();
                //設定された番号のカメラから写真を撮る
                camera.TakePhoto((int)upDownCamera.Value);
                //撮った写真をPictureBoxに出力
                takePhotoPictureBox.Image = camera.bitmap;
                //顔検出した結果をPictureBoxに出力
                takePhotoPictureBox.Image = camera.GetDetectedFace();
            }
            catch (Exception ex)
            {
                LogManager.LogOutput(ex.Message);
             }
        }
        
        private void labelName_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 講義削除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click_1(object sender, EventArgs e)
        {
            //講義が選択されていない
            if(listBox1.SelectedIndex < 0)
            {
                LogManager.LogOutput("削除できる講義がありません");
            }
            else
            {
                //ダイアログを出す
                DialogResult dialogResult = 
                    MessageBox.Show("講義を削除します\r\nいいですか?", "講義削除", MessageBoxButtons.YesNo);

                //Yesなら
                if(dialogResult == DialogResult.Yes)
                {
                    //削除処理
                    try
                    {
                        LogManager.LogOutput("講義を削除: " + listBox1.SelectedItem.ToString());
                        MessageBox.Show("講義を削除しました");
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        listBox1.SelectedIndex = -1;
                    }
                    catch (NullReferenceException)
                    {
                        
                    }
                }
            }
        }

        /// <summary>
        /// 講義追加設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //講義名入力InputBox
            string s1 = Microsoft.VisualBasic.Interaction.InputBox("講義名を入力していください。", "講義名設定", "", -1, -1);
            //講義の追加
            listBox1.Items.Add(s1);
            LogManager.LogOutput("講義を追加: " + s1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                numericUpDown1.Text = "9";
                numericUpDown2.Text = "30";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                numericUpDown1.Text = "11";
                numericUpDown2.Text = "10";
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                numericUpDown1.Text = "13";
                numericUpDown2.Text = "30";
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                numericUpDown1.Text = "15";
                numericUpDown2.Text = "10";
            }
        }

        /// <summary>
        /// 選択した時限の設定を呼び出す
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                button3.Enabled = true;
                label10.Text = listBox1.SelectedItem.ToString();
            }
            else
            {
                button3.Enabled = false;
                label10.Text = string.Empty;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// カメラ番号が変更された時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDownCamera_ValueChanged(object sender, EventArgs e)
        {
            //準備が出来ていなかったら終了
            if (!ready) return;
            //番号を保存
            cameraIndex.WriteData(upDownCamera.Value.ToString());
        }

        /// <summary>
        /// リンククリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //URLに飛ばす
            System.Diagnostics.Process.Start("https://www.aut.ac.jp/");
        }
    }
}

