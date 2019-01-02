using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BussinessLibrary.Log
{
    public class Log
    {
        private readonly static string FilePath = AppDomain.CurrentDomain.BaseDirectory + @"log\"+DateTime.Now.ToString("yyyy-M-d dddd")+"_log.txt";
        public static void WriterLog(string logContent)
        {
            using (FileStream stream = new FileStream(FilePath, FileMode.Append))
            using (StreamWriter writer = new StreamWriter(stream))
            {
                writer.WriteLine(DateTime.Now+"  "+logContent);
            }
        }

    }
}
