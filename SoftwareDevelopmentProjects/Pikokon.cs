using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FelicaLib;

namespace SoftwareDevelopmentProjects
{
    public partial class Pikokon : Form
    {
        private CameraClass camera;                         //実装用のカメラクラス
        private CameraClass testCamera;                     //テスト用のカメラクラス
        private bool ready = false;                         //初期化が完了したかどうか

        private MiniFileManager cameraIndexMan;             //カメラ番号ファイルの操作クラス
        private MiniFileManager lectureTimeMan;             //講義時間ファイルの操作クラス
        private MiniFileManager lectureName;                //講義名
        private MiniFileManager detectType;                 //検出場所

        private SoundManager soundManager;                  //音声管理クラス

        private string[] lectureTime;                       //講義時間保存
        private List<int> lectureStartTime;                 //講義開始時刻保存

        public Pikokon()
        {
            InitializeComponent();

            //サイズを初期化
            this.Width = 617;
            this.Height = 618;

            //名簿フォルダを作成
            Directory.CreateDirectory("名簿フォルダ");

            //時間更新タイマーを起動
            dateTimer.Start();

            //ログ出力に使用するテキストボックスを指定
            LogManager.logTextBox = logText;
            
            //表示用リスト初期化
            listStudentId.View = View.Details;
            listStudentId.GridLines = true;

            //系列追加
            listStudentId.Columns.Add("学籍番号", 100, HorizontalAlignment.Right);
            listStudentId.Columns.Add("出席時刻", 100, HorizontalAlignment.Right);

            /*
            //リストに画像を表示するための設定
            ImageList imageListSmall = new ImageList();
            imageListSmall.ImageSize = new Size(1, 30);
            listStudentId.SmallImageList = imageListSmall;
            */

            //カメラ番号を保存するクラスの初期化
            cameraIndexMan = new MiniFileManager("cameraSettings.pico");

            //カメラ番号を保存するクラスから読み取った数値をカメラ番号に設定
            upDownCamera.Value = int.Parse(cameraIndexMan.ReadData("0"));

            //講義開始時間を保存するクラスの初期化
            lectureTimeMan = new MiniFileManager("lectureSettings.pico");

            //講義名を保存するクラスの初期化
            lectureName = new MiniFileManager("lectureList.pico");

            //検出場所を保存するクラスの初期化
            detectType = new MiniFileManager("detectType.pico");

            //講義別の開始時刻を保存するリストの初期化
            lectureStartTime = new List<int>();

            //保存された講義名ファイルを配列に入れる
            string[] lectureNames = lectureName.ReadDataArray("");

            //講義のデータを初期化
            for(int i = 0; i < lectureNames.Length; i++)
            {
                if(lectureNames[i] != "")
                {
                    //講義名と講義時間データに分ける
                    string[] lectureData = lectureNames[i].Split(',');

                    //講義名を追加
                    listBox1.Items.Add(lectureData[0]);

                    //講義開始時間を追加
                    lectureStartTime.Add(int.Parse(lectureData[1]));
                }
            }

            //テストカメラの認識項目初期化
            upDownDetectType.SelectedIndex = int.Parse(detectType.ReadData("0"));

            //コンボボックスの中身の初期化
            for(int i = 0; i < lectureNames.Length; i++)
            {
                if(lectureNames[i] != "")
                {
                    string[] lectureNamesArray = lectureNames[i].Split(',');
                    LectureSelectComboBox.Items.Add(lectureNamesArray[0]);
                }
            }

            //初期化用の講義開始時間
            string[] defaultTime =
            {
                "9,30",
                "11,10",
                "13,30",
                "15,10"
            };

            //講義開始時間保存クラスから読み取った数値をlectureTimeに読みだす
            //ファイルがなかった場合は初期化用の講義開始時間で初期化
            lectureTime = lectureTimeMan.ReadDataArray(defaultTime);

            //カメラクラスの初期化
            camera = new CameraClass();
            testCamera = new CameraClass();

            //音声管理クラスの初期化
            soundManager = new SoundManager();

            //乱数最大値の初期化
            reaPerTextBox.Text = soundManager.randMax.ToString();
            SetReaSoundPer();

            //初期化終了
            ready = true;
        }

        /// <summary>
        /// 学籍番号読み取り開始ボタンの切り替え
        /// </summary>
        private void ToggleFelica()
        {
            //ボタンのロックを切り替え
            checkBoxDetectFace.Enabled = !checkBoxDetectFace.Enabled;

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
            if (LectureSelectComboBox.SelectedIndex < 0)
            {
                LogManager.LogOutput("講義を選択してください");
                return;
            }
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
                //指定した特徴量を削除
                camera.RemoveFaceDess(listStudentId.Items.IndexOf(listStudentId.SelectedItems[0]));
                //指定した学籍番号をリストから削除
                listStudentId.Items.Remove(listStudentId.SelectedItems[0]);
                LogManager.LogOutput("選択した項目を削除");
            }
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
                            fericaLoadTimer.Stop();
                            MessageBox.Show("学生証をきちんとかざしてください", "情報", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            fericaLoadTimer.Start();
                            return;
                        }
                        for (int i = 0; i < listStudentId.Items.Count; i++)
                        {
                            if (listStudentId.Items[i].SubItems[0].Text == str)
                            {
                                //同名の学籍番号
                                return;
                            }
                        }

                        //ズル防止にチェックが入っていたら
                        if (checkBoxDetectFace.Checked)
                        {
                            //カメラから写真を撮る
                            camera.TakePhoto((int)upDownCamera.Value);
                            //顔が検知できなかったら
                            if (camera.DetectFace() == false)
                            {
                                fericaLoadTimer.Stop();
                                MessageBox.Show("カメラに顔が写るようにしてください", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                LogManager.LogOutput("顔の検出失敗");
                                fericaLoadTimer.Start();
                                return;
                            }
                            //識別するだけのデータが存在
                            if (camera.faceDessCount > 1)
                            {
                                //総当たりで比較
                                for (int i = 0; i < camera.faceDessCount - 1; i++)
                                {
                                    if(camera.CompareFeature(DessType.TypeFace, i, camera.faceDessCount - 1))
                                    {
                                        fericaLoadTimer.Stop();
                                        MessageBox.Show("カード利用の不正を確認しました", "不正確認", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        MessageBox.Show("相違度: " + camera.GetFeatureValue(DessType.TypeFace, i, camera.faceDessCount - 1));
                                        //重複した顔を削除
                                        camera.RemoveFaceDess(camera.faceDessCount - 1);
                                        fericaLoadTimer.Start();
                                        return;
                                    }
                                }
                            }
                        }

                        soundManager.PlaySound();

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
            if(LectureSelectComboBox.SelectedIndex < 0)
            {
                LogManager.LogOutput("講義を選択してください");
                return;
            }
            //データを保存しやすいように変換
            SaveClass.ConvertToSaveData(listStudentId.Items);
            //保存
            SaveClass.ExportCsv(LectureSelectComboBox.SelectedItem.ToString());
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
            //設定された番号のカメラから写真を撮る
            testCamera.TakePhoto((int)upDownCamera.Value);
            //撮った写真をPictureBoxに出力
            takePhotoPictureBox.Image = testCamera.bitmap;

            //選択されている検出設定に応じて処理を変える
            switch (upDownDetectType.SelectedIndex)
            {
                case 0:
                    if (testCamera.DetectFace())
                    {
                        //顔検出した結果をPictureBoxに出力
                        takePhotoPictureBox.Image = testCamera.faceBitmap;
                        //特徴量画像を出力
                        featurePictureBox.Image = testCamera.GetFeaturePicture(DessType.TypeFace, testCamera.faceDessCount - 1);

                        if (testCamera.faceDessCount > 1)
                        {
                            //出力
                            featureCompareLabel.Text = "比較: (" + (testCamera.faceDessCount - 1) + ", " + (testCamera.faceDessCount - 2) + ")";
                            float featureValue = testCamera.GetFeatureValue(DessType.TypeFace, testCamera.faceDessCount - 1, testCamera.faceDessCount - 2);
                            featureValueLabel.Text = "相違度: " + featureValue.ToString("F2");
                        }
                    }
                    break;

                case 1:
                    if (testCamera.DetectEyes())
                    {
                        //目検出した結果をPictureBoxに出力
                        takePhotoPictureBox.Image = testCamera.eyesBitmap;
                        //特徴量画像を出力
                        featurePictureBox.Image = testCamera.GetFeaturePicture(DessType.TypeEyes, testCamera.eyesDessCount - 1);

                        if (testCamera.eyesDessCount > 1)
                        {
                            //出力
                            featureCompareLabel.Text = "比較: (" + (testCamera.eyesDessCount - 1) + ", " + (testCamera.eyesDessCount - 2) + ")";
                            float featureValue = testCamera.GetFeatureValue(DessType.TypeEyes, testCamera.eyesDessCount - 1, testCamera.eyesDessCount - 2);
                            featureValueLabel.Text = "相違度: " + featureValue.ToString("F2");
                        }
                    }
                    break;

                default:
                    break;

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
                        lectureStartTime.RemoveAt(listBox1.SelectedIndex);
                        listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        listBox1.SelectedIndex = -1;
                        //講義名ファイルの更新
                        string saveLecture = "";
                        for (int i = 0; i < listBox1.Items.Count; i++)
                        {
                            if(listBox1.Items[i].ToString() != "")
                            {
                                saveLecture += "\n" + listBox1.Items[i] + "," + lectureStartTime[i];
                            }
                        }
                        lectureName.WriteData(saveLecture);
                        //コンボボックスの更新
                        LectureSelectComboBox.Items.Clear();
                        foreach(string lectureItems in listBox1.Items)
                        {
                            LectureSelectComboBox.Items.Add(lectureItems);
                        }

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
            string lecture = Microsoft.VisualBasic.Interaction.InputBox("講義名を入力してください。", "講義名設定", "", -1, -1);
            if(!string.IsNullOrWhiteSpace(lecture))
            {
                //講義の追加
                listBox1.Items.Add(lecture);
                //データの読み取り
                string saveLecture = lectureName.ReadData("");
                //新しいデータの追加
                saveLecture += "\n" + lecture + ",0";
                //データの保存
                lectureName.WriteData(saveLecture);
                //講義開始時間の設定
                lectureStartTime.Add(0);
                //コンボボックスの更新
                LectureSelectComboBox.Items.Clear();
                foreach (string lectureItems in listBox1.Items)
                {
                    LectureSelectComboBox.Items.Add(lectureItems);
                }
                LogManager.LogOutput("講義を追加: " + lecture);
            } else
            {
                LogManager.LogOutput("講義追加失敗");
            }
            /*
            //講義の追加
            listBox1.Items.Add(lecture);
            //データの読み取り
            string saveLecture = lectureName.ReadData("");
            //新しいデータの追加
            saveLecture += "\n" + lecture + ",0";
            //データの保存
            lectureName.WriteData(saveLecture);
            //講義開始時間の設定
            lectureStartTime.Add(0);
            //コンボボックスの更新
            LectureSelectComboBox.Items.Clear();
            foreach (string lectureItems in listBox1.Items)
            {
                LectureSelectComboBox.Items.Add(lectureItems);
            }
            LogManager.LogOutput("講義を追加: " + lecture); */
        }

        /// <summary>
        /// 講義の開始時刻を変更
        /// </summary>
        /// <param name="time">開始時刻タグ</param>
        private void ChangeLectureStartTime(int time)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                //選択されている講義の開始時刻を変更する
                lectureStartTime[listBox1.SelectedIndex] = time;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                //lectureTimeから指定した時限の講義開始時間を取得
                string[] startTime = lectureTime[0].Split(',');
                numericUpDown1.Text = startTime[0];
                numericUpDown2.Text = startTime[1];
                //選択されている講義の講義開始時間を0に設定
                ChangeLectureStartTime(0);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                //lectureTimeから指定した時限の講義開始時間を取得
                string[] startTime = lectureTime[1].Split(',');
                numericUpDown1.Text = startTime[0];
                numericUpDown2.Text = startTime[1];
                //選択されている講義の講義開始時間を1に設定
                ChangeLectureStartTime(1);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                //lectureTimeから指定した時限の講義開始時間を取得
                string[] startTime = lectureTime[2].Split(',');
                numericUpDown1.Text = startTime[0];
                numericUpDown2.Text = startTime[1];
                //選択されている講義の講義開始時間を2に設定
                ChangeLectureStartTime(2);
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked)
            {
                //lectureTimeから指定した時限の講義開始時間を取得
                string[] startTime = lectureTime[3].Split(',');
                numericUpDown1.Text = startTime[0];
                numericUpDown2.Text = startTime[1];
                //選択されている講義の講義開始時間を3に設定
                ChangeLectureStartTime(3);
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

                //設定されている講義時間のチェックボックスを選択
                switch (lectureStartTime[listBox1.SelectedIndex])
                {
                    case 0:
                        radioButton3.Checked = true;
                        break;

                    case 1:
                        radioButton4.Checked = true;
                        break;

                    case 2:
                        radioButton5.Checked = true;
                        break;

                    case 3:
                        radioButton6.Checked = true;
                        break;
                }
            }
            else
            {
                button3.Enabled = false;
                label10.Text = string.Empty;
            }
        }

        /// <summary>
        /// 講義時間保存処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            //保存用変数
            string lectureData = "";
            //保存用変数にデータをまとめる
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                lectureData += listBox1.Items[i] + "," + lectureStartTime[i] + "\r\n";
            }
            //講義名、開始時間を保存
            lectureName.WriteData(lectureData);
            //限目の講義開始時間を設定
            lectureTimeMan.WriteData(lectureTime);

            //ログ
            LogManager.LogOutput("講義時間を保存");
            MessageBox.Show("講義時間を保存しました");
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
            cameraIndexMan.WriteData(upDownCamera.Value.ToString());
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

        /// <summary>
        /// 講義開始時が変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //時間情報をlectureTimeに保存
            SaveLectureStartTime();
        }

        /// <summary>
        /// 講義開始分が変更されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //時間情報をlectureTimeに保存
            SaveLectureStartTime();
        }

        /// <summary>
        /// 時間情報をlectureTimeに格納
        /// </summary>
        private void SaveLectureStartTime()
        {
            //現在の開始時刻設定を保存しやすいように変更
            string saveStr = numericUpDown1.Value + "," + numericUpDown2.Value;

            if (radioButton3.Checked)//1限目なら
            {
                lectureTime[0] = saveStr;
            }
            else if (radioButton4.Checked)//2限目なら
            {
                lectureTime[1] = saveStr;
            }
            else if (radioButton5.Checked)//3限目なら
            {
                lectureTime[2] = saveStr;
            }
            else if (radioButton6.Checked)//4限目なら
            {
                lectureTime[3] = saveStr;
            }
        }

        private void LectureSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //listBox1選択時にescを押すと選択解除
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Escape)
            {
                try
                {
                    listBox1.SelectedIndex = -1;
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// クリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void faceFeatureResetButton_Click(object sender, EventArgs e)
        {
            testCamera.Clear();
        }

        /// <summary>
        /// 検出場所を保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upDownDetectType_SelectedItemChanged(object sender, EventArgs e)
        {
            //保存
            detectType.WriteData(upDownDetectType.SelectedIndex.ToString());
            //目検出なら
            if (upDownDetectType.SelectedIndex == 1)
            {
                testProvider.SetError(upDownDetectType, "テスト段階の機能です\r\n意図しない動作が起こる可能性があります");
            }
            else
            {
                testProvider.Clear();
            }
        }

        /// <summary>
        /// サウンドテストボタン用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playPictureBox_Click(object sender, EventArgs e)
        {
            //出席音声を再生,乱数を表示
            soundNameLabel.Text = soundManager.PlaySound().ToString();
        }

        /// <summary>
        /// レア音声再生確率を計算する
        /// </summary>
        private void SetReaSoundPer()
        {
            //計算
            reaPerCalcLabel.Text = "= " + (7.0 / (double)soundManager.randMax * 100.0).ToString("F2") + "%";
        }

        private void reaPerTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!ready) return;
            try
            {
                //乱数の最大値を設定
                soundManager.randMax = int.Parse(reaPerTextBox.Text);
                //レア音声再生確率を設定
                SetReaSoundPer();
            }
            //数字以外が入力された
            catch (System.FormatException)
            {
                //数字に上書き
                reaPerTextBox.Text = soundManager.randMax.ToString();
            }
        }

        private void folderPictureBox_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
    "EXPLORER.EXE", Directory.GetCurrentDirectory() + "\\名簿フォルダ");
        }
    }
}

