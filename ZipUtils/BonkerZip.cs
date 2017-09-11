﻿using System.Collections.Generic;
using System.IO;
using System;
using ICSharpCode.SharpZipLib.Zip;

namespace ZipUtils
{
    public class BonkerZip
    {
        /// <summary>
        /// 存放待压缩的文件的绝对路径
        /// </summary>
        private List<string> AbsolutePaths { set; get; }
        public string errorMsg { set; get; }

        public BonkerZip()
        {
            errorMsg = "";
            AbsolutePaths = new List<string>();
        }
        /// <summary>
        /// 添加压缩文件
        /// </summary>
        /// <param name="_fileAbsolutePath">文件的绝对路径</param>
        public void AddFile(string _fileAbsolutePath)
        {
            AbsolutePaths.Add(_fileAbsolutePath);
        }
        /// <summary>
        /// 压缩文件或者文件夹
        /// </summary>
        /// <param name="_depositPath">压缩后文件的存放路径   如C:\\windows\abc.zip</param>
        /// <returns></returns>
        public bool CompressionZip(string _depositPath)
        {
            bool result = true;
            FileStream fs = null;
            try
            {
                ZipOutputStream ComStream = new ZipOutputStream(File.Create(_depositPath));
                ComStream.SetLevel(9);      //压缩等级
                foreach (string path in AbsolutePaths)
                {
                    //如果是目录
                    if (Directory.Exists(path))
                    {
                        ZipFloder(path, ComStream, path);
                    }
                    else if (File.Exists(path))//如果是文件
                    {
                         fs = File.OpenRead(path);
                        byte[] bts = new byte[fs.Length];
                        fs.Read(bts, 0, bts.Length);
                        ZipEntry ze = new ZipEntry(new FileInfo(path).Name);
                        ComStream.PutNextEntry(ze);             //为压缩文件流提供一个容器
                        ComStream.Write(bts, 0, bts.Length);  //写入字节
                    }
                }
                ComStream.Finish(); // 结束压缩
                ComStream.Close();
            }
            catch (Exception ex)
            {
                if (fs != null)
                {
                    fs.Close();
                }
                errorMsg = ex.Message;
                result = false;
            }
            return result;
        }
        //压缩文件夹
        private void ZipFloder(string _OfloderPath, ZipOutputStream zos, string _floderPath)
        {
            foreach (FileSystemInfo item in new DirectoryInfo(_floderPath).GetFileSystemInfos())
            {
                if (Directory.Exists(item.FullName))
                {
                    ZipFloder(_OfloderPath, zos, item.FullName);
                }
                else if (File.Exists(item.FullName))//如果是文件
                {
                    DirectoryInfo ODir = new DirectoryInfo(_OfloderPath);
                    string fullName2 = new FileInfo(item.FullName).FullName;
                    string path = ODir.Name + fullName2.Substring(ODir.FullName.Length, fullName2.Length - ODir.FullName.Length);//获取相对目录
                    FileStream fs = File.OpenRead(fullName2);
                    byte[] bts = new byte[fs.Length];
                    fs.Read(bts, 0, bts.Length);
                    ZipEntry ze = new ZipEntry(path);
                    zos.PutNextEntry(ze);             //为压缩文件流提供一个容器
                    zos.Write(bts, 0, bts.Length);  //写入字节
                }
            }
        }
        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="_depositPath">压缩文件路径</param>
        /// <param name="_floderPath">解压的路径</param>
        /// <returns></returns>
        public bool DeCompressionZip(string _depositPath, string _floderPath)
        {
            if (!File.Exists(_depositPath))
                return true;
            bool result = true;
            FileStream fs=null;
            try
            {
                ZipInputStream InpStream = new ZipInputStream(File.OpenRead(_depositPath));
                ZipEntry ze = InpStream.GetNextEntry();//获取压缩文件中的每一个文件
                if (!string.IsNullOrEmpty(_floderPath))
                    Directory.CreateDirectory(_floderPath);//创建解压文件夹
                while (ze != null)//如果解压完ze则是null
                {
                    if (ze.IsFile)//压缩zipINputStream里面存的都是文件。带文件夹的文件名字是文件夹\\文件名
                    {

                        try
                        {
                            string strpaht = Path.GetDirectoryName(ze.Name);
                            if (!string.IsNullOrEmpty(_floderPath)&& !string.IsNullOrEmpty(strpaht))
                            {
                                strpaht =Path.Combine( _floderPath , strpaht);
                            }
                            if (!string.IsNullOrEmpty(strpaht))
                                Directory.CreateDirectory(strpaht);
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ze.Name);

                        }

                        string filepath = ze.Name;
                        if (!string.IsNullOrEmpty(_floderPath))
                        {
                            filepath = Path.Combine(_floderPath, filepath);
                        }

                        if (!File.Exists(filepath))
                        {
                            fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);//创建文件
                                                                                                      //循环读取文件到文件流中
                            while (true)
                            {
                                byte[] bts = new byte[1024];
                                int i = InpStream.Read(bts, 0, bts.Length);
                                if (i > 0)
                                {
                                    fs.Write(bts, 0, i);
                                }
                                else
                                {
                                    fs.Flush();
                                    fs.Close();
                                    break;
                                }
                            }
                        }
                    }
                    try
                    {
                        ze = InpStream.GetNextEntry();
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show(ex.Message + "\n" + ze.Name);

                    }
                    
                }
            }
            catch (Exception ex)
            {
               
                errorMsg = ex.Message;
                result = false;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return result;
        }

    }
}
