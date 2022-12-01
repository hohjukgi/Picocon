# Picocon
~~愛知工科大学~~学生証を利用した出席管理アプリ

## 概要
Felica学生証とPasoriを使用した出席管理を行います<br>
~~[愛知工科大学](https://www.aut.ac.jp/)の学生証のみ対応しています~~<br>
※別の大学学生証についても対応させる予定

>**注意:**
>このプログラムを動作させるためには別売のICリーダ<br>
>PaSoRi [RC-S300](https://www.sony.co.jp/Products/felica/consumer/) が必要です

## 要求要件(ソフトウェアのみ)
- windows 10
- PaSoRi RC-S300
- [NFCポートソフトウェア](https://www.sony.co.jp/Products/felica/consumer/support/download/nfcportsoftware.html?j-short=fsc_dl)

## プロジェクト動作
- .NET Core 3.1
- Fericalib.dll [[元配布ページ]](http://felicalib.tmurakam.org/)
[[ダウンロード]](https://github.com/hohjukgi/Test/files/9956930/felicalib-0.4.2.zip)
- NuGet: [OpenCvSharp4.Extensions](https://www.nuget.org/packages/OpenCvSharp4.Extensions/4.6.0.20220608?_src=template)
- NuGet: [OpenCvSharp4.Windows](https://www.nuget.org/packages/OpenCvSharp4.Windows/4.6.0.20220608?_src=template)
- [haarcascade_frontalface_default.xml](https://github.com/opencv/opencv/tree/master/data/haarcascades)
