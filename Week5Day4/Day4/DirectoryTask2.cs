using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day4
{
    internal class DirectoryTask2
    {
        static void Main()
        {
            string path = "@C:\\Test";
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                int count = 0;
                foreach (var file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    Console.WriteLine(fi.Name);
                    Console.WriteLine(fi.Length);
                    Console.WriteLine(fi.CreationTime);
                    count++;
                }
                Console.WriteLine($"number of files in the folder: {count}");
            }
            else
            {
                Console.WriteLine("invalid folder path");
            }
        }
    }
}
