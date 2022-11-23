
namespace SoftwareDevelopmentProjects
{
    partial class Pikokon
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimer = new System.Windows.Forms.Timer(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.fericaLoadTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.logText = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.namePicture = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.namePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(32, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 73);
            this.button1.TabIndex = 0;
            this.button1.Text = "開始";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(32, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 95);
            this.button2.TabIndex = 6;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(387, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 41);
            this.label2.TabIndex = 8;
            this.label2.Text = "時間";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // dateTimer
            // 
            this.dateTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listView1
            // 
            this.listView1.AutoArrange = false;
            this.listView1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(178, 35);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(302, 359);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(32, 195);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(108, 41);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // fericaLoadTimer
            // 
            this.fericaLoadTimer.Interval = 1000;
            this.fericaLoadTimer.Tick += new System.EventHandler(this.fericaLoadTimer_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 12;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 30);
            this.tabControl1.Location = new System.Drawing.Point(32, 91);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(516, 481);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.logText);
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(508, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "出席登録";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(29, 398);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Message:";
            // 
            // logText
            // 
            this.logText.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.logText.Location = new System.Drawing.Point(32, 414);
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.logText.Size = new System.Drawing.Size(448, 19);
            this.logText.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(508, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // namePicture
            // 
            this.namePicture.Image = global::SoftwareDevelopmentProjects.Properties.Resources.icon;
            this.namePicture.Location = new System.Drawing.Point(12, 12);
            this.namePicture.Name = "namePicture";
            this.namePicture.Size = new System.Drawing.Size(200, 50);
            this.namePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.namePicture.TabIndex = 12;
            this.namePicture.TabStop = false;
            // 
            // Pikokon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(601, 584);
            this.Controls.Add(this.namePicture);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Name = "Pikokon";
            this.Text = "Picocon";
            this.Load += new System.EventHandler(this.Pikokon_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.namePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer dateTimer;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Timer fericaLoadTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox namePicture;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.Label label1;
    }
}

