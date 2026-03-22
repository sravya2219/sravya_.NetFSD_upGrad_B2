using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day4
{
    internal class DirectoryTask4
    {
        static void Main()
        {
            DirectoryInfo di = new DirectoryInfo("C:\\Users\\ASUS\\OneDrive\\Documents");
            if (di.Exists)
            {
                var subdirs = di.GetDirectories();
                foreach(var dirs in subdirs)
                {
                    Console.WriteLine(dirs.Name);
                    Console.WriteLine(dirs.CreationTime);
                }
                var files = di.GetFiles();
                int count = 0;
                foreach(var file in files)
                {
                    count++;
                }
                Console.WriteLine($"number of files: {count}");

            }
            else
            {
                Console.WriteLine("invalid directory");
            }

        }
    }
}
