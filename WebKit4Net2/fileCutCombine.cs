using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ChromeForDoNet
{
   public class fileCutCombine
    {
        /// <summary>
        /// 分割文件方法
        /// </summary>
        /// <param name="filePath">被分割文件</param>

        /// <param name="cutFileSize">被分割文件大小</param>
        /// <returns>分割后的文件</returns>
     public  static string[] CutFile(string filePath, int cutFileSize)
        {
            string[] result;

            string strExtension = Path.GetExtension(filePath);
            //文件流读取文件
            using (FileStream cutFileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {

                //二进制读取器
                using (BinaryReader cutFileReader = new BinaryReader(cutFileStream))
                {
                    byte[] cutBytes;

                    //分割的文件个数
                    int fileCount = Convert.ToInt32(Math.Ceiling((double)cutFileStream.Length / cutFileSize));
                    result = new string[fileCount];
                    string saveFilePath = Application.StartupPath + "\\ChromeOrn\\";
                    if (Directory.Exists(saveFilePath))
                    {
                        DeleteFolderRecursive(Directory.CreateDirectory(saveFilePath));
                        // Directory.Delete(saveFilePath, true);
                    }
                    else
                    Directory.CreateDirectory(saveFilePath);
                    for (int i = 0; i < fileCount; i++)
                    {
                        //分割文件保存路径
                       

                        //分割文件名
                        string cutFileName = Path.Combine(saveFilePath, Path.GetFileNameWithoutExtension(filePath)) +"_" + i.ToString().PadLeft(4,'0')+ strExtension;
                        result[i] = cutFileName;
                        if (File.Exists(cutFileName))
                            File.Delete(cutFileName);
                        if (!Directory.Exists(saveFilePath))
                            Directory.CreateDirectory(saveFilePath);
                        //分割文件流
                        using (FileStream tempStream = new FileStream(cutFileName, FileMode.OpenOrCreate))
                        {

                            //分割文件二进制写入器
                            using (BinaryWriter tempWriter = new BinaryWriter(tempStream))
                            {
                                cutBytes = cutFileReader.ReadBytes(cutFileSize);
                                tempWriter.Write(cutBytes);
                               
                            }
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 合并文件
        /// </summary>
        /// <param name="filePaths">要合并的文件列表</param>
        /// <param name="combineFile">合并后的文件路径带文件名</param>
     public static  void CombineFiles(string[] filePaths, string combineFile)
        {

            if (File.Exists(combineFile))
                File.Delete(combineFile);
            byte[] Dllbyte = new byte[] { };
            using (FileStream CombineStream = new FileStream(combineFile, FileMode.OpenOrCreate))
            {
                using (BinaryWriter CombineWriter = new BinaryWriter(CombineStream))
                {

                    foreach (string file in filePaths)
                    {

                        using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                        {
                            using (BinaryReader fileReader = new BinaryReader(fileStream))
                            {
                                byte[] TempBytes = fileReader.ReadBytes((int)fileStream.Length);
                                Dllbyte = Combine(Dllbyte, TempBytes);
                                CombineWriter.Write(TempBytes);
                            }
                        }
                    }
                }
            }

            // foreach (string file in filePaths)
            // {

            //     using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
            //     {
            //         using (BinaryReader fileReader = new BinaryReader(fileStream))
            //         {
            //             byte[] TempBytes = fileReader.ReadBytes((int)fileStream.Length);
            //             Dllbyte = Combine(Dllbyte, TempBytes);

            //         }
            //     }
            // }

            // Assembly a = AppDomain.CurrentDomain.Load(Dllbyte);
            //Type myType = a.GetType("ChromeForDoNet.WebKitBrower4Net2");
            //object obj = Activator.CreateInstance(myType);

        }

        private static byte[] Combine(byte[] a, byte[] b)
        {
            byte[] c = new byte[a.Length + b.Length];
            System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
            System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
            return c;
        }
       
        private static void DeleteFolderRecursive(DirectoryInfo baseDir)
        {
            baseDir.Attributes = FileAttributes.Normal;
            foreach (var childDir in baseDir.GetDirectories())
                DeleteFolderRecursive(childDir);

            foreach (var file in baseDir.GetFiles())
                file.IsReadOnly = false;

            baseDir.Delete(true);
        }
        internal static void ComFile4Chrome()
        {
            string[] strpath = Directory.GetFiles("ChromeOrn");
            Array.Sort(strpath, string.CompareOrdinal);
            CombineFiles(strpath, "costura32.zip");
        }

        
    }
}
