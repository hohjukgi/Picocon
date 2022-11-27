using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace SoftwareDevelopmentProjects
{
    internal class CameraClass
    {
        private Mat _flame;
        public Bitmap bitmap
        {
            get { 
                return BitmapConverter.ToBitmap(_flame);
            }
        }

        public CameraClass()
        {
            _flame = null;
        }

        /// <summary>
        /// カメラから写真を撮る
        /// 撮った写真は_flameに格納される
        /// </summary>
        public void TakePhoto()
        {
            using (var capture = new VideoCapture())
            {
                //カメラの起動　
                capture.Open(0);

                if (!capture.IsOpened())
                {
                    LogManager.LogOutput("キャプチャーの初期化失敗");
                    return;
                }

                //画像取得用のMatを作成
                _flame = new Mat();

                while (true)
                {
                    try
                    {
                        capture.Read(_flame);
                        if (_flame.Empty())
                        {
                            break;
                        }

                        if (_flame.Size().Width > 0)
                        {
                            //MatをBitMapに変換
                            return;
                        }

                    }

                    catch (Exception)
                    {
                        break;
                    }
                }
                return;
            }
        }

        /// <summary>
        /// _flameに保存されている画像から
        /// 顔検出を行う
        /// </summary>
        /// <returns>検出した顔</returns>
        /// <exception cref="Exception">失敗した際の例外</exception>
        public Bitmap DetectFace()
        {
            // 結果画像
            Mat matRetImage = null;

            if (_flame == null)
            {
                throw new Exception("Image is null");
            }

            string classifierFilePath = Application.StartupPath + @"..\..\..\DetectFace\haarcascade_frontalface_default.xml";

            if (!File.Exists(classifierFilePath))
            {
                LogManager.LogOutput("顔認識用カスケードファイルがみつかりません");
                return null;
            }

            // 顔認識用カスケード分類器を作成
            using (var haarCascade = new CascadeClassifier(classifierFilePath))

            // 判定画像ファイルをロード
            using (var matSrcImage = _flame)
            using (var matGrayscaleImage = new Mat())
            {
                matRetImage = matSrcImage.Clone();

                // 入力画像をグレースケール化
                Cv2.CvtColor(
                    src: matSrcImage,
                    dst: matGrayscaleImage,
                    code: ColorConversionCodes.BGR2GRAY);

                // 顔認識を実行
                var faces = haarCascade.DetectMultiScale(
                    image: matGrayscaleImage,
                    scaleFactor: 1.1,
                    minNeighbors: 3,
                    minSize: new OpenCvSharp.Size(100, 100));

                // 認識した顔の周りを枠線で囲む
                foreach (var face in faces)
                {
                    Cv2.Rectangle(
                        img: matRetImage,
                        rect: new Rect(face.X, face.Y, face.Width, face.Height),
                        //color: new Scalar(0, 255, 255),
                        color: new Scalar(0, 0, 255),
                        thickness: 2);
                }
            }

            // 結果画像を表示
            Bitmap retBitmap = BitmapConverter.ToBitmap(matRetImage);

            matRetImage.Dispose();
            return retBitmap;
        }
    }
}
