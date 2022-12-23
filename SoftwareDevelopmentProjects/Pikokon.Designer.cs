using System;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pikokon));
            this.buttonRead = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.dateTimer = new System.Windows.Forms.Timer(this.components);
            this.listStudentId = new System.Windows.Forms.ListView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.fericaLoadTimer = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LectureSelectComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxDetectFace = new System.Windows.Forms.CheckBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.logText = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.featureValueLabel = new System.Windows.Forms.Label();
            this.featureCompareLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.featurePictureBox = new System.Windows.Forms.PictureBox();
            this.faceFeatureResetButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.upDownDetectType = new System.Windows.Forms.DomainUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.upDownCamera = new System.Windows.Forms.NumericUpDown();
            this.takePhotoPictureBox = new System.Windows.Forms.PictureBox();
            this.ImageProcessingTestButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.PictureBox();
            this.testProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.featurePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCamera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.takePhotoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.testProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRead
            // 
            this.buttonRead.BackColor = System.Drawing.Color.Transparent;
            this.buttonRead.Location = new System.Drawing.Point(32, 35);
            this.buttonRead.Name = "buttonRead";
            this.buttonRead.Size = new System.Drawing.Size(108, 73);
            this.buttonRead.TabIndex = 0;
            this.buttonRead.Text = "開始";
            this.buttonRead.UseVisualStyleBackColor = false;
            this.buttonRead.Click += new System.EventHandler(this.button1_Click);
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
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.BackColor = System.Drawing.Color.Transparent;
            this.labelTime.Font = new System.Drawing.Font("UD デジタル 教科書体 NK-B", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTime.Location = new System.Drawing.Point(387, 12);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(88, 41);
            this.labelTime.TabIndex = 8;
            this.labelTime.Text = "時間";
            // 
            // dateTimer
            // 
            this.dateTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // listStudentId
            // 
            this.listStudentId.AutoArrange = false;
            this.listStudentId.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.listStudentId.HideSelection = false;
            this.listStudentId.Location = new System.Drawing.Point(178, 35);
            this.listStudentId.Name = "listStudentId";
            this.listStudentId.Size = new System.Drawing.Size(302, 359);
            this.listStudentId.TabIndex = 9;
            this.listStudentId.UseCompatibleStateImageBehavior = false;
            this.listStudentId.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged_1);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
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
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.tabPage1.Controls.Add(this.LectureSelectComboBox);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.checkBoxDetectFace);
            this.tabPage1.Controls.Add(this.radioButton2);
            this.tabPage1.Controls.Add(this.radioButton1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.logText);
            this.tabPage1.Controls.Add(this.buttonDelete);
            this.tabPage1.Controls.Add(this.buttonRead);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.listStudentId);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(508, 443);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "出席登録";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // LectureSelectComboBox
            // 
            this.LectureSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LectureSelectComboBox.FormattingEnabled = true;
            this.LectureSelectComboBox.Location = new System.Drawing.Point(224, 6);
            this.LectureSelectComboBox.Name = "LectureSelectComboBox";
            this.LectureSelectComboBox.Size = new System.Drawing.Size(256, 24);
            this.LectureSelectComboBox.TabIndex = 17;
            this.LectureSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.LectureSelectComboBox_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(178, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "講義:";
            // 
            // checkBoxDetectFace
            // 
            this.checkBoxDetectFace.AutoSize = true;
            this.checkBoxDetectFace.Location = new System.Drawing.Point(32, 169);
            this.checkBoxDetectFace.Name = "checkBoxDetectFace";
            this.checkBoxDetectFace.Size = new System.Drawing.Size(85, 20);
            this.checkBoxDetectFace.TabIndex = 15;
            this.checkBoxDetectFace.Text = "ズル防止";
            this.checkBoxDetectFace.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(32, 143);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 20);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.Text = "退席";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 117);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 20);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "出席";
            this.radioButton1.UseVisualStyleBackColor = true;
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
            this.tabPage2.Controls.Add(this.featureValueLabel);
            this.tabPage2.Controls.Add(this.featureCompareLabel);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.featurePictureBox);
            this.tabPage2.Controls.Add(this.faceFeatureResetButton);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.upDownDetectType);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.radioButton6);
            this.tabPage2.Controls.Add(this.radioButton5);
            this.tabPage2.Controls.Add(this.radioButton4);
            this.tabPage2.Controls.Add(this.radioButton3);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.upDownCamera);
            this.tabPage2.Controls.Add(this.takePhotoPictureBox);
            this.tabPage2.Controls.Add(this.ImageProcessingTestButton);
            this.tabPage2.Controls.Add(this.button4);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.numericUpDown2);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(508, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "設定";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // featureValueLabel
            // 
            this.featureValueLabel.AutoSize = true;
            this.featureValueLabel.Location = new System.Drawing.Point(313, 416);
            this.featureValueLabel.Name = "featureValueLabel";
            this.featureValueLabel.Size = new System.Drawing.Size(27, 16);
            this.featureValueLabel.TabIndex = 29;
            this.featureValueLabel.Text = "0.0";
            // 
            // featureCompareLabel
            // 
            this.featureCompareLabel.AutoSize = true;
            this.featureCompareLabel.Location = new System.Drawing.Point(310, 394);
            this.featureCompareLabel.Name = "featureCompareLabel";
            this.featureCompareLabel.Size = new System.Drawing.Size(56, 16);
            this.featureCompareLabel.TabIndex = 28;
            this.featureCompareLabel.Text = "相違度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(231, 361);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 27;
            this.label14.Text = "特徴量画像";
            // 
            // featurePictureBox
            // 
            this.featurePictureBox.Location = new System.Drawing.Point(234, 382);
            this.featurePictureBox.Name = "featurePictureBox";
            this.featurePictureBox.Size = new System.Drawing.Size(70, 50);
            this.featurePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.featurePictureBox.TabIndex = 26;
            this.featurePictureBox.TabStop = false;
            // 
            // faceFeatureResetButton
            // 
            this.faceFeatureResetButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.faceFeatureResetButton.Location = new System.Drawing.Point(411, 405);
            this.faceFeatureResetButton.Name = "faceFeatureResetButton";
            this.faceFeatureResetButton.Size = new System.Drawing.Size(91, 32);
            this.faceFeatureResetButton.TabIndex = 25;
            this.faceFeatureResetButton.Text = "リセット";
            this.faceFeatureResetButton.UseVisualStyleBackColor = true;
            this.faceFeatureResetButton.Click += new System.EventHandler(this.faceFeatureResetButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(296, 306);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 16);
            this.label13.TabIndex = 24;
            this.label13.Text = "認識方法";
            // 
            // upDownDetectType
            // 
            this.upDownDetectType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.upDownDetectType.Items.Add("顔認識");
            this.upDownDetectType.Items.Add("目認識");
            this.upDownDetectType.Location = new System.Drawing.Point(299, 325);
            this.upDownDetectType.Name = "upDownDetectType";
            this.upDownDetectType.ReadOnly = true;
            this.upDownDetectType.Size = new System.Drawing.Size(78, 23);
            this.upDownDetectType.TabIndex = 23;
            this.upDownDetectType.Text = "domainUpDown1";
            this.upDownDetectType.SelectedItemChanged += new System.EventHandler(this.upDownDetectType_SelectedItemChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(74, 23);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(0, 15);
            this.label10.TabIndex = 22;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(329, 123);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(50, 20);
            this.radioButton6.TabIndex = 21;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "4限";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(329, 97);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(50, 20);
            this.radioButton5.TabIndex = 20;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "3限";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(329, 71);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(50, 20);
            this.radioButton4.TabIndex = 19;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "2限";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(329, 44);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(50, 20);
            this.radioButton3.TabIndex = 18;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "1限";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 289);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "カメラ設定";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(231, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "カメラ";
            // 
            // upDownCamera
            // 
            this.upDownCamera.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.upDownCamera.Location = new System.Drawing.Point(234, 325);
            this.upDownCamera.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.upDownCamera.Name = "upDownCamera";
            this.upDownCamera.ReadOnly = true;
            this.upDownCamera.Size = new System.Drawing.Size(37, 23);
            this.upDownCamera.TabIndex = 15;
            this.upDownCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.upDownCamera.ValueChanged += new System.EventHandler(this.upDownCamera_ValueChanged);
            // 
            // takePhotoPictureBox
            // 
            this.takePhotoPictureBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.takePhotoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.takePhotoPictureBox.Location = new System.Drawing.Point(6, 307);
            this.takePhotoPictureBox.Name = "takePhotoPictureBox";
            this.takePhotoPictureBox.Size = new System.Drawing.Size(220, 130);
            this.takePhotoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.takePhotoPictureBox.TabIndex = 14;
            this.takePhotoPictureBox.TabStop = false;
            // 
            // ImageProcessingTestButton
            // 
            this.ImageProcessingTestButton.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ImageProcessingTestButton.Location = new System.Drawing.Point(411, 367);
            this.ImageProcessingTestButton.Name = "ImageProcessingTestButton";
            this.ImageProcessingTestButton.Size = new System.Drawing.Size(91, 32);
            this.ImageProcessingTestButton.TabIndex = 13;
            this.ImageProcessingTestButton.Text = "検出テスト";
            this.ImageProcessingTestButton.UseVisualStyleBackColor = true;
            this.ImageProcessingTestButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(385, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(55, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "保存";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "開始";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "分";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "時";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(385, 211);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(37, 23);
            this.numericUpDown2.TabIndex = 8;
            this.numericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(301, 211);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(37, 23);
            this.numericUpDown1.TabIndex = 7;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "時限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "講義";
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(203, 71);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(23, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(31, 41);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 196);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.linkLabel1);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(508, 443);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "クレジット";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(3, 185);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(118, 16);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "大学ホームページ";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(470, 176);
            this.label12.TabIndex = 0;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // labelName
            // 
            this.labelName.Image = global::SoftwareDevelopmentProjects.Properties.Resources.icon;
            this.labelName.Location = new System.Drawing.Point(12, 12);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(200, 50);
            this.labelName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.labelName.TabIndex = 12;
            this.labelName.TabStop = false;
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // testProvider
            // 
            this.testProvider.ContainerControl = this;
            // 
            // Pikokon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(601, 579);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTime);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Pikokon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Picocon";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.featurePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upDownCamera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.takePhotoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.labelName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.testProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRead;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Timer dateTimer;
        private System.Windows.Forms.ListView listStudentId;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Timer fericaLoadTimer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox labelName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.PictureBox takePhotoPictureBox;
        private System.Windows.Forms.Button ImageProcessingTestButton;
        private System.Windows.Forms.NumericUpDown upDownCamera;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxDetectFace;
        private System.Windows.Forms.ComboBox LectureSelectComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.DomainUpDown upDownDetectType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button faceFeatureResetButton;
        private System.Windows.Forms.PictureBox featurePictureBox;
        private System.Windows.Forms.Label featureValueLabel;
        private System.Windows.Forms.Label featureCompareLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ErrorProvider testProvider;
    }
}

