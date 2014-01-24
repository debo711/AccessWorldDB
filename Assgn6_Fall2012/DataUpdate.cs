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
    class DataUpdate
    {
        public static void Insert(MySqlConnection conn, Log log, int transNum, string InsertThisSQL)
        {
            string[] InsertCorCL = InsertThisSQL.Split(':');

            string SQL = "INSERT INTO " + InsertCorCL[0];
            if (InsertCorCL.Length < 3)
            {
                SQL += " VALUES (" + InsertCorCL[1] + ")";
            }
            else
            {
                SQL += " (" + InsertCorCL[1] + ") VALUES (" +
                    InsertCorCL[2] + ")";
            }

            log.WriteThis(string.Format("SQL ({0}): {1}", transNum, SQL));

            MySqlCommand cmd = new MySqlCommand(SQL, conn);

            try
            {
                cmd.ExecuteNonQuery();
                log.WriteThis(string.Format("OK, Data INSERTED\r\n"));
            }
            catch (Exception ex)
            {
                log.WriteThis(string.Format("ERROR on {0}, INSERT not done", transNum));
                log.WriteThis(ex.ToString() + "\r\n");
                Console.WriteLine("ERROR on {0}, INSERT not done", transNum);
            }
        }
        // ***********************************************************************************
        public static void Update(MySqlConnection conn, Log log, int transNum, string UpdateThisSQL)
        {
            log.WriteThis(string.Format("SQL ({0}): {1}", transNum, UpdateThisSQL));

            MySqlCommand cmd = new MySqlCommand(UpdateThisSQL, conn);

            try
            {
                cmd.ExecuteNonQuery();
                log.WriteThis(string.Format("OK, Data UPDATED\r\n"));
            }
            catch (Exception ex)
            {
                log.WriteThis(string.Format("ERROR on {0}, UPDATE not done", transNum));
                log.WriteThis(ex.ToString() + "\r\n");
                Console.WriteLine("ERROR on {0}, UPDATE not done", transNum);
            }
        }
        // *************************************************************************************
        public static void Delete(MySqlConnection conn, Log log, int transNum, string DeleteThisSQL)
        {
            string[] DeleteCorCL = DeleteThisSQL.Split(':');

            string SQL = "DELETE FROM " + DeleteCorCL[0] + " WHERE " + DeleteCorCL[1] +
                " = " + DeleteCorCL[2];

            log.WriteThis(string.Format("SQL ({0}): {1}", transNum, SQL));

            MySqlCommand cmd = new MySqlCommand(SQL, conn);

            try
            {
                cmd.ExecuteNonQuery();
                log.WriteThis(string.Format("OK, Data DELETED\r\n"));
            }
            catch (Exception ex)
            {
                log.WriteThis(string.Format("ERROR on {0}, DELETE not done", transNum));
                log.WriteThis(ex.ToString() + "\r\n");
                Console.WriteLine("ERROR on {0}, DELETE not done", transNum);
            }
        }
    }
}
