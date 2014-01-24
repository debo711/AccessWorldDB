using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace Assgn6_Fall2012
{
    class Program
    {
        static void Main(string[] args)
        {
            Log LogFile = new Log();
            StreamReader SR = new StreamReader("..//..//..//WorldTrans.txt");

            string password;
            Console.Write("Enter your MySQL password: ");
            password = Console.ReadLine();

            string connStr = "server=localhost;user=root;database=world;" +
                "port=3306;password=" + password + ";";

            MySqlConnection conn;
            int SQLcount = 0;

            LogFile.WriteThis("Connecting to MySQL...");

            try
            {
                conn = new MySqlConnection(connStr);
                conn.Open();
                LogFile.WriteThis("OK, the DB Connection is OPENED\r\n");

                while (!SR.EndOfStream)
                {
                    string lineread = SR.ReadLine();
                    char trans = lineread[0];
                    char[] splitter = { ' ' };
                    string[] lineRet = lineread.Split(splitter, 2);
                    SQLcount++;

                    LogFile.WriteThis(lineread);
                    switch (trans)
                    {
                        case 'D':
                            DataUpdate.Delete(conn, LogFile, SQLcount, lineRet[1]);
                            break;
                        case 'I':
                            DataUpdate.Insert(conn, LogFile, SQLcount, lineRet[1]);
                            break;
                        case 'U':
                            DataUpdate.Update(conn, LogFile, SQLcount, lineread);
                            break;
                        case 'S':
                            DataRetrieval.SelectFromDB(conn, LogFile, SQLcount, lineread);
                            break;
                    }
                }

                conn.Close();
                Console.WriteLine("See LogSession.txt in top-level project folder");
            }
            catch (Exception ex)
            {
                LogFile.WriteThis("ERROR, DB Connection didn't work - no trans done");
                LogFile.WriteThis(ex.ToString() + "\r\n");
                Console.WriteLine("ERROR, DB Connection didn't work - no trans done");
            }

            LogFile.WriteThis("EXITING PROGRAM");
            LogFile.Close();

            // ************************************
            Console.Write("\n\nHit ENTER to quit ");
            Console.ReadLine();
        }
    }
}
