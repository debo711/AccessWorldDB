using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assgn6_Fall2012
{
    public class Log
    {
        StreamWriter SW;
        private string path = "..//..//..//";

        // ********************************* CONSTRUCTOR ****************************
        public Log()
        {
            SW = new StreamWriter(path + "LogSession.txt", true);
        }

        // ********************************* WRITE ****************************
        public void WriteThis(string line)
        {
            SW.WriteLine(line);
        }

        // ********************************* FINISH **********************
        public void Close()
        {
            SW.Close();
        }
    }
}
