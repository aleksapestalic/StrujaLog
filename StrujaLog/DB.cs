using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrujaLog
{
    class DB
    {
        public static string MyConnection2 = "server=remotemysql.com;uid=1Q4YGu3UBP;pwd=lU73WBad3G;database=1Q4YGu3UBP";
        //pass lU73WBad3G

        #region executeSqlQuery
        public static void execute(string sqlCommand)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection2);
            try
            {
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sqlCommand;
                comm.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion

        #region select 6
        public static List<string> select6(string sqlCommand) //vraca listu sa redovima podataka naguranim u jednu recenicu na osnovu upita (SELECT * FROM table -> sqlCommand)
        {
            MySqlConnection conn = new MySqlConnection(MyConnection2);
            try
            {
                List<string> rows = new List<string>();
                conn.Open();
                MySqlCommand comm = conn.CreateCommand();
                comm.CommandText = sqlCommand;


                MySqlDataReader reader = comm.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        rows.Add(reader.GetString(0) + "|" + reader.GetString(1) + "|" + reader.GetString(2) + "|" + reader.GetString(3) + "|" + reader.GetString(4) + "|" + reader.GetString(5));
                    }
                    conn.Close();
                    return rows;
                }
                else
                {
                    conn.Close();
                    rows = null; return rows;
                }

            }
            catch
            {
                conn.Close();
                throw;
            }
        }
        #endregion
    }
}
