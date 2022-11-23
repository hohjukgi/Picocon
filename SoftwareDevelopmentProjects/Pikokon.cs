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
        public List<string> studentId;
        public Pikokon()
        {
            InitializeComponent();

            studentId = new List<string>();

            dateTimer.Start();

            listView1.View = View.Details;
            listView1.GridLines = true;

            listView1.Columns.Add("学籍番号", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("出席時刻", 100, HorizontalAlignment.Left);

            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(1, 30);
            listView1.SmallImageList = imageListSmall;

            logText.Text = "初期化完了";
        }

        /// <summary>
        /// 学籍番号読み取り開始ボタンの切り替え
        /// </summary>
        private void ToggleFelica()
        {
            fericaLoadTimer.Enabled = !fericaLoadTimer.Enabled;
            if (button1.Text == "開始")
            {
                //例外発生防止のため、ボタン操作を停止する
                button1.Enabled = false;
                button1.Text = "停止";
            }
            else
            {
                button1.Enabled = true;
                button1.Text = "開始";
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
            label2.Text = datetime.ToString("MM月dd日\nHH:mm:ss");
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

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                //指定した学籍番号をリストから削除
                studentId.Remove(listView1.SelectedItems[0].Text);
                listView1.Items.Remove(listView1.SelectedItems[0]);
                logText.Text = "削除成功";
            }
            else
            {
                logText.Text = "削除失敗";
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
                            return;
                        }
                        for (int i = 0; i < studentId.Count; i++)
                        {
                            if (studentId[i] == str)
                            {
                                //同名の学籍番号
                                return;
                            }
                        }

                        //オーディオ再生処理
                        Task task = Task.Run(() =>
                        {
                        //オーディオリソースを取り出す
                        System.IO.Stream strm = Properties.Resources.system_sound;
                        //同期再生する
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(strm);
                            player.PlaySync();
                        //後始末
                        player.Dispose();
                        });

                        DateTime dateTime = DateTime.Now;
                        string[] row = { str, dateTime.ToString("t") };
                        listView1.Items.Add(new ListViewItem(row));
                        studentId.Add(str);
                        logText.Text = "学生証を読み取りました";
                    }
                    catch (Exception)//学生証を読み取れなかった場合など
                    {
                        //ボタンの追操作を許可
                        button1.Enabled = true;
                    }
                }
            } 
            catch (Exception ex)//重大な例外
            {
                //読み取りを停止する
                ToggleFelica();
                logText.Text = ex.Message;
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}

