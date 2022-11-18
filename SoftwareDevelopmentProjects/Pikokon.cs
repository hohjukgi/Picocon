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


        }

        private void ToggleFelica()
        {
            fericaLoadTimer.Enabled = !fericaLoadTimer.Enabled;
            if (button1.Text == "開始")
            {
                button1.Text = "停止";
            }
            else
            {
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
            label2.Text = datetime.ToString();
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
                        string str = FericaFunc.readStudentId(f);
                        if (str == "00000000")
                        {
                            return;
                        }
                        for (int i = 0; i < studentId.Count; i++)
                        {
                            if (studentId[i] == str)
                            {
                                return;
                            }
                        }

                        DateTime dateTime = DateTime.Now;
                        string[] row = { str, dateTime.ToString("t") };
                        listView1.Items.Add(new ListViewItem(row));
                        studentId.Add(str);
                        //リスト項目を追加
                    }
                    catch (Exception)
                    {

                    }

                }
            } catch (Exception ex)
            {
                ToggleFelica();
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }
    }
}

