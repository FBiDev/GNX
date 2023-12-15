﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace GNX.Desktop
{
    public static class Archive
    {
        public static string LastUpdate(string fileName)
        {
            if (File.Exists(fileName)) { return File.GetLastWriteTime(fileName).ToString(); }
            return "";
        }

        public static string RelativePath(string fileName)
        {
            var info = new FileInfo(fileName);
            string path = ".\\" + info.DirectoryName.Replace(AppDomain.CurrentDomain.BaseDirectory, "") + "\\";
            return path;
        }

        public static string MakeValidFileName(string name)
        {
            var invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            var invalidRegStr = string.Format(@"([{0}]*\.+$)|([{0}]+)", invalidChars);

            return Regex.Replace(name, invalidRegStr, "_");
        }

        public static List<string> RemoveDuplicates(List<string> list)
        {
            var files = list.Select(f =>
            {
                using (FileStream fs = new FileStream(f, FileMode.Open, FileAccess.Read))
                {
                    //var crc32 = BitConverter.ToString(CRC32.Create().ComputeHash(fs));
                    //fs.Position = 0;
                    var md5 = BitConverter.ToString(MD5.Create().ComputeHash(fs));

                    return new
                    {
                        FileName = f,
                        MD5 = md5,
                        //FileHash = sha1,
                    };
                }
            });

            files = files.Distinct();
            return files.Select(f => f.FileName).ToList();
        }

        public static List<string> RemoveImageSize(List<string> list, Size size)
        {
            var files = list.Where(f =>
            {
                var pic = new Picture(f);

                return pic.Size != size;
            });

            return files.ToList();
        }

        public static string CalculateSize(double _bytes)
        {
            string unitSimbol = _bytes < 1024 ? "bytes" :
                _bytes < 1048576 ? "KB" : "MB";

            double unitSize = _bytes < 1024 ? _bytes :
                _bytes < 1048576 ? _bytes / 1024 : _bytes / 1024 / 1024;

            if (unitSize < 10) { return (Math.Floor(unitSize * 100) / 100).ToString("n2") + " " + unitSimbol; }
            if (unitSize < 100) { return (Math.Floor(unitSize * 10) / 10).ToString("n1") + " " + unitSimbol; }
            return Math.Floor(unitSize) + " " + unitSimbol;
        }

        public static bool IsFileLocked(string fileName)
        {
            try
            {
                using (FileStream stream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}