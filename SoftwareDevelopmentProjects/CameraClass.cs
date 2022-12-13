using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace SoftwareDevelopmentProjects
{
    internal class CameraClass
    {
        //画像を格納する配列
        private Mat _flame;

        //顔画像を格納する配列
        private Mat _face;

        //特徴量の配列
        private List<Mat> dess;

        //特徴点の配列
        private List<KeyPoint[]> points;

        //_flameをビットマップ画像に変換したもの
        public Bitmap bitmap
        {
            get { 
                return BitmapConverter.ToBitmap(_flame);
            }
        }

        //_faceをビットマップ画像に変換したもの
        public Bitmap faceBitmap
        {
            get
            {
                return BitmapConverter.ToBitmap(_face);
            }
        }

        //dessの配列数
        public int dessCount
        {
            get
            {
                return dess.Count;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public CameraClass()
        {
            _face = null;
            _flame = null;
            dess = new List<Mat>();
            points = new List<KeyPoint[]>();
        }


        /// <summary>
        /// カメラから写真を撮る
        /// 撮った写真は_flameに格納される
        /// </summary>
        public void TakePhoto(int selectedCamera)
        {
            using (var capture = new VideoCapture())
            {
                //カメラの起動　
                capture.Open(selectedCamera);

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
        /// 顔が検出されたか
        /// </summary>
        /// <returns>bool</returns>
        public bool DetectFace()
        {
            //顔画像を削除
            _face = null;

            //画像が撮影されていないなら
            if (_flame == null)
            {
                //顔は検出されなかった
                LogManager.LogOutput("フレームがnullです");
                return false;
            }

            Mat matRetImage = new Mat();

            //必須ファイル
            string classifierFilePath = @"haarcascade_frontalface_default.xml";

            //カスケードファイルが見つからなかったら
            if (!File.Exists(classifierFilePath))
            {
                //顔は検出されなかった
                LogManager.LogOutput("顔認識用カスケードファイルがみつかりません");
                return false;
            }

            // 顔認識用カスケード分類器を作成
            using (var haarCascade = new CascadeClassifier(classifierFilePath))

            // 判定画像ファイルをロード
            using (var matGrayscaleImage = new Mat())
            {
                // 入力画像をグレースケール化
                Cv2.CvtColor(
                    src: _flame.Clone(),
                    dst: matGrayscaleImage,
                    code: ColorConversionCodes.BGR2GRAY);

                // 顔認識を実行
                var faces = haarCascade.DetectMultiScale(
                    image: matGrayscaleImage,
                    scaleFactor: 1.1,
                    minNeighbors: 3,
                    minSize: new OpenCvSharp.Size(100, 100));

                //顔検出に失敗時か、顔が検出されなかったら
                if(faces == null || faces.Length <= 0)
                {
                    //顔は検出されなかった
                    LogManager.LogOutput("顔の検出に失敗");
                    return false;
                }

                //一番大きい(近い)顔
                Rect maxRect = new Rect();

                //一番大きい(近い)顔の座標
                int rectMaxSize = 0;

                // 一番近い顔を判断
                foreach (var face in faces)
                {

                    //検出した顔の大きさ
                    int rectSize = face.Width * face.Height;

                    //現在の一番大きい顔の大きさよりも大きいなら
                    if (rectSize > rectMaxSize)
                    {
                        //代入
                        rectMaxSize = rectSize;
                        maxRect = new Rect(face.X, face.Y, face.Width, face.Height);
                    }
                }

                //顔画像のみを格納するMatを作成
                matRetImage = new Mat(maxRect.Height, maxRect.Width, MatType.CV_16SC1);

                //顔画像を格納
                for (int y = 0; y < maxRect.Height; y++)
                {
                    for (int x = 0; x < maxRect.Width; x++)
                    {
                        matRetImage.At<int>(y,x) = _flame.At<int>(y + maxRect.Height,x + maxRect.Width);
                    }
                }

            }

            //顔を格納
            _face = matRetImage;

            //計算用ファイルを破棄
            matRetImage.Dispose();

            //特徴点抽出
            ExtractFeatureValue();

            LogManager.LogOutput("顔の検出に成功");

            return true;
        }

        /// <summary>
        /// 画像の特徴点、特徴量を抽出する
        /// </summary>
        private void ExtractFeatureValue()
        {
            try
            {
                //抽出元の変数が存在しないなら
                if (_flame == null)
                {
                    throw new Exception("フレームがnullです");
                }

                //グレースケール画像保存クラス
                Mat gray = new Mat();

                //グレースケールに変換
                Cv2.CvtColor(_face, gray, ColorConversionCodes.RGB2GRAY);

                //特徴量比較クラスを生成
                AKAZE aKAZE = AKAZE.Create();

                //特徴点
                KeyPoint[] keyPoints;

                //各特徴点に対応する特徴記述子
                Mat des = new Mat();

                //特徴量と特徴点を抽出する
                aKAZE.DetectAndCompute(gray, null, out keyPoints, des);

                //抽出した各要素をListに格納
                dess.Add(des);
                points.Add(keyPoints);

            }catch(Exception ex)
            {
                LogManager.LogOutput(ex.Message);
            }
        }

        /// <summary>
        /// arg1とarg2の特徴量距離(類似度)を算出する
        /// 値が小さいほど似ている
        /// </summary>
        /// <param name="arg1">特徴量1</param>
        /// <param name="arg2">特徴量2</param>
        /// <returns>特徴量距離</returns>
        public float CompareFeature(int arg1, int arg2)
        {
            if(arg1 < 0 || arg2 < 0)
            {
                throw new Exception("引数が0未満です");
            }

            if (arg1 > (dess.Count - 1) || arg2 > (dess.Count - 1))
            {
                throw new Exception("引数が配列の要素数を超えています");
            }

            //BFMatcherを生成
            BFMatcher bFMatcher = new BFMatcher(NormTypes.Hamming, true);

            //マッチング
            DMatch[] dm = bFMatcher.Match(dess[arg1], dess[arg2]);

            //特徴量距離を格納する変数
            float[] dist = new float[dm.Length];

            //sumを格納する変数
            float sum = 0;

            //sumと特徴量距離を計算する
            for(int i = 0; i < dm.Length; i++)
            {
                //特徴量距離
                dist[i] = dm[i].Distance;

                //sum
                sum += dist[i];
            }

            //特徴量距離の平均を求め、返却
            return (sum / dist.Length);
        }
    }
}
