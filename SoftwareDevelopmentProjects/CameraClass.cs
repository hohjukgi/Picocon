using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace SoftwareDevelopmentProjects
{
    internal class CameraClass
    {
        private Mat _flame;
        public Bitmap Image
        {
            get { 
                return BitmapConverter.ToBitmap(_flame);
            }
        }

        public CameraClass()
        {
            _flame = null;
        }

        public void TakePhoto()
        {
            using (var capture = new VideoCapture())
            {
                //カメラの起動　
                capture.Open(0);

                if (!capture.IsOpened())
                {
                    throw new Exception("capture initialization failed");
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
    }
}
