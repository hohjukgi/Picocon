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

        private const string CAMERA_FILE_NAME = "cameraSettings.pico";
        private bool ready = false;

        public Pikokon()
        {
            InitializeComponent();

            dateTimer.Start();

            LogManager.logTextBox = logText;
            
            listStudentId.View = View.Details;
            listStudentId.GridLines = true;


            listStudentId.Columns.Add("学籍番号", 100, HorizontalAlignment.Left);
            listStudentId.Columns.Add("出席時刻", 100, HorizontalAlignment.Left);

            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(1, 30);
            listStudentId.SmallImageList = imageListSmall;

            try
            {
                string str = string.Empty;
                using (StreamReader sr = new StreamReader(CAMERA_FILE_NAME))
                {
                    str = sr.ReadLine();
                    upDownCamera.Value = int.Parse(str);
                }
            }
            catch (FileNotFoundException)
            {
                using(StreamWriter sw = new StreamWriter(CAMERA_FILE_NAME, false))
                {
                    sw.WriteLine("0");
                }
            }
            catch(Exception ex)
            {
                LogManager.LogOutput(ex.Message);
            }

            LogManager.LogOutput("初期化完了");

            ready = true;
        }

        /// <summary>
        /// 学籍番号読み取り開始ボタンの切り替え
        /// </summary>
        private void ToggleFelica()
        {
            fericaLoadTimer.Enabled = !fericaLoadTimer.Enabled;
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
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;

            //時間ラベルを更新する
            labelTime.Text = datetime.ToString("MM月dd日\nHH:mm:ss");
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }

        


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(listStudentId.SelectedItems.Count > 0)
            {
                buttonDelete.Enabled = true;
            }
            else
            {
                buttonDelete.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listStudentId.SelectedItems.Count > 0)
            {
                //指定した学籍番号をリストから削除
                listStudentId.Items.Remove(listStudentId.SelectedItems[0]);
                LogManager.LogOutput("選択した項目を削除");
            }
            else
            {
                
            }
        }

        private void Pikokon_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

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

                        DateTime dateTime = DateTime.Now;
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveClass.ConvertToSaveData(listStudentId.Items);
            SaveClass.ExportCsv();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                CameraClass camera = new CameraClass();
                camera.TakePhoto((int)upDownCamera.Value);
                takePhotoPictureBox.Image = camera.bitmap;
                takePhotoPictureBox.Image = camera.GetDetectedFace();
            }
            catch (Exception ex)
            {
                LogManager.LogOutput(ex.Message + "\r\n");
             }
        }
        
        private void labelName_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex < 0)
            {
                LogManager.LogOutput("削除できる講義がありません");
            }
            else
            {
                DialogResult dialogResult = 
                    MessageBox.Show("講義を削除します\r\nいいですか?", "講義削除", MessageBoxButtons.YesNo);

                if(dialogResult == DialogResult.Yes)
                {
                    MessageBox.Show(listBox1.SelectedIndex.ToString());
                    LogManager.LogOutput("講義を削除: " + listBox1.SelectedItem.ToString());
                    MessageBox.Show("講義を削除しました");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string s1 = Microsoft.VisualBasic.Interaction.InputBox("講義名を入力していください。", "講義名設定", "", -1, -1);
            listBox1.Items.Add(s1);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label10.Text = listBox1.SelectedItem.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void upDownCamera_ValueChanged(object sender, EventArgs e)
        {
            if (!ready) return;
            try
            {
                using (StreamWriter sw = new StreamWriter(CAMERA_FILE_NAME, false))
                {
                    sw.WriteLine(upDownCamera.Value.ToString());
                }
                LogManager.LogOutput("カメラ設定の保存");
            }
            catch(Exception ex)
            {
                LogManager.LogOutput(ex.Message);
            }
        }
    }
}

