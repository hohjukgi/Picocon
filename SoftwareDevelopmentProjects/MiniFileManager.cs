using System;
using System.Collections.Generic;
using System.IO;

namespace SoftwareDevelopmentProjects
{
    /// <summary>
    /// ちょっとしたファイル入出力管理を行うクラス
    /// </summary>
    class MiniFileManager
    {
        /// <summary>
        /// ファイル名(元)
        /// </summary>
        private string _fileName;

        /// <summary>
        /// ファイル名(公衆)
        /// </summary>
        public string fileName
        {
            get
            {
                return _fileName;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="fileName">ファイル名</param>
        public MiniFileManager(string fileName)
        {
            _fileName = fileName;
        }

        /// <summary>
        /// 指定したファイルからデータを読む
        /// ファイルが見つからなかった場合はinitializeStringで上書き
        /// </summary>
        /// <param name="initializeString">ファイルが見つからなかった際に書き込む値</param>
        /// <returns></returns>
        public string ReadData(string initializeString)
        {
            string data = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    data = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {
                        sw.Write(initializeString);
                    }
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        data = sr.ReadToEnd();
                    }
                }catch(Exception ex)
                {
                    LogManager.LogOutput(ex.Message);
                    throw new Exception(ex.ToString());
                }
            }
            catch(Exception ex)
            {
                LogManager.LogOutput(ex.Message);
                throw new Exception(ex.ToString());
            }
            return data;
        }

        /// <summary>
        /// 指定したファイルからデータを読む
        /// ファイルが見つからなかった場合はinitializeStringで上書き
        /// </summary>
        /// <param name="initializeString">ファイルが見つからなかった際に書き込む値(配列)</param>
        /// <returns></returns>
        public string ReadData(string[] initializeString)
        {
            string data = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    data = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {
                        foreach(string str in initializeString)
                        {
                            sw.WriteLine(str);
                        }
                    }
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        data = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {
                    LogManager.LogOutput(ex.Message);
                    throw new Exception(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.LogOutput(ex.Message);
                throw new Exception(ex.ToString());
            }
            return data;
        }

        /// <summary>
        /// ファイルから文章を配列で読み取る
        /// ファイルが存在しない場合はinitializeStringで上書きされる
        /// </summary>
        /// <param name="initializeString">上書きする値</param>
        /// <returns></returns>
        public string[] ReadDataArray(string initializeString)
        {
            string data = string.Empty;
            List<string> listData = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    data = sr.ReadLine();
                    while (data != null)
                    {
                        listData.Add(data);
                        data = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {
                        sw.WriteLine(initializeString);
                    }
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        data = sr.ReadLine();
                        while (data != null)
                        {
                            listData.Add(data);
                            data = sr.ReadLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.LogOutput(ex.Message);
                    throw new Exception(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.LogOutput(ex.Message);
                throw new Exception(ex.ToString());
            }
            return listData.ToArray();
        }

        /// <summary>
        /// ファイルから文章を配列で読み取る
        /// ファイルが存在しない場合はinitializeStringで上書きされる
        /// </summary>
        /// <param name="initializeString">上書きする値(配列)</param>
        /// <returns></returns>
        public string[] ReadDataArray(string[] initializeString)
        {
            string data = string.Empty;
            List<string> listData = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    data = sr.ReadLine();
                    while(data != null)
                    {
                        listData.Add(data);
                        data = sr.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName, false))
                    {
                        foreach (string str in initializeString)
                        {
                            sw.WriteLine(str);
                        }
                    }
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        data = sr.ReadLine();
                        while (data != null)
                        {
                            listData.Add(data);
                            data = sr.ReadLine();
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.LogOutput(ex.Message);
                    throw new Exception(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                LogManager.LogOutput(ex.Message);
                throw new Exception(ex.ToString());
            }
            return listData.ToArray();
        }

        /// <summary>
        /// データを書き込む
        /// </summary>
        /// <param name="data">書き込むデータ</param>
        public void WriteData(string data)
        {
            try
            {
                using(StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.Write(data);
                }
            }catch(Exception ex)
            {
                LogManager.LogOutput(ex.Message);
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// データを書き込む
        /// </summary>
        /// <param name="data">書き込むデータ(配列)</param>
        public void WriteData(string[] data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    foreach (string str in data)
                    {
                        sw.WriteLine(str);
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.LogOutput(ex.Message);
                throw new Exception(ex.ToString());
            }
        }
    }
}
