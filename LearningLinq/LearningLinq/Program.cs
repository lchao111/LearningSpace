using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace LearningLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\windows";
        }


        static void ShowTheLargestFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach (var item in query.Take(5))
            {
                Console.WriteLine($"{item.Length,-1} : {item.Name,1:N0}");
            }

        }
        static void ShowTheLargestFiles(string path)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            FileInfo[] files = info.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            foreach (var f in files)
            {
                Console.WriteLine($"{f.Name} : {f.Length}");
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
