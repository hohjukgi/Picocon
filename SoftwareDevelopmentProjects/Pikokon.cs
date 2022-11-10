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

namespace SoftwareDevelopmentProjects
{
    public partial class Pikokon : Form
    {
        public Pikokon()
        {
            InitializeComponent();

            timer1.Start();

            listView1.View = View.Details;

            listView1.Columns.Add("クラス");
            listView1.Columns.Add("名前");
            listView1.Columns.Add("講義名");
            listView1.Columns.Add("時刻");

            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(1, 30);
            listView1.SmallImageList = imageListSmall;


        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "ダイアログのタイトルをココに書く";
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.FileName = "初期表示するファイル名をココに書く";
            openFileDialog1.Filter = "テキスト ファイル|*.txt;*.log|すべてのファイル|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Multiselect が true の場合はこのように列挙する
                foreach (string nFileName in openFileDialog1.FileNames)
                {
                    ListViewItem lvitem;

                    //Path.GetFileName(nFileName)でパスからファイル名を所得する
                    lvitem = listView1.Items.Add(Path.GetFileName(nFileName));
                    lvitem.SubItems.Add(nFileName);


                }

                //ListViewのすべての列を自動調節
                foreach (ColumnHeader ch in listView1.Columns)
                {
                    ch.Width = -1;
                }
            }

            // 不要になった時点で破棄する (正しくは オブジェクトの破棄を保証する を参照)
            openFileDialog1.Dispose();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;

            label2.Text = datetime.ToLongTimeString();
        }


        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.GridLines = true;

            listView1.Columns.Add("ファイル名", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("ファイルパス", 200, HorizontalAlignment.Left);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }

        private void Pikokon_Load(object sender, EventArgs e)
        {

        }
    }
}

