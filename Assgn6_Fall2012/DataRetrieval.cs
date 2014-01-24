using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Assgn6_Fall2012
{
    class DataRetrieval
    {
        public static void SelectFromDB(MySqlConnection connec, Log log, int transNum, string QueryThisSQL)
        {
            log.WriteThis(string.Format("SQL ({0}): {1}", transNum, QueryThisSQL));

            MySqlCommand Cmnd = new MySqlCommand(QueryThisSQL, connec);

            try
            {
                MySqlDataReader RDR = Cmnd.ExecuteReader();

                while (RDR.Read())
                {
                    string output = "";
                    for (int i = 0; i < RDR.FieldCount; i++)
                    {
                        output += (string.Format("{0}   ", RDR[i]));
                    }
                    log.WriteThis(output);
                }
                log.WriteThis("\n");
                RDR.Close();
            }
            catch (Exception ex)
            {
                log.WriteThis(string.Format("ERROR on {0}, QUERY not done", transNum));
                log.WriteThis(ex.ToString() + "\r\n");
                Console.WriteLine("ERROR on {0}, QUERY not done", transNum);
            }
        }
    }
}
