using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionMakingConstructors.HandsOn.WEEK5.Day4
{
    internal class FileHandlingTask1
    {
        static void Main()
        {
            try
            {

                Console.Write("Enter message");
                string msg = Console.ReadLine();
                FileStream fs = new FileStream("logo.txt", FileMode.Append, FileAccess.Write);
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                fs.Write(data, 0, data.Length);
                fs.Close();
                Console.WriteLine("message saved");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
    }
    }
}
