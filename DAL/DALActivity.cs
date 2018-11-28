using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALActivity
    {
        public static string connectionstring = @"Server=mssql.fhict.local;Database=dbi392873;User Id=dbi392873;Password=killerapp;";
        SqlConnection conn = new SqlConnection(connectionstring);
        private bool openConnection()
        {
            bool result = true;

            try
            {
                conn.Open();
            }
            catch (DataException dex)
            {
                result = false;
            }
            return result;
        }

        public void InsertActivityIntoDB(string activityname, string address, string city, DateTime datetime)
        {
            openConnection();
            string query = "INSERT INTO [Activity] (activityname, city, address, datetime) " +
                "VALUES (@activityname, @city, @address, @datetime";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("activityname", activityname));
            cmd.Parameters.Add(new SqlParameter("city", city));
            cmd.Parameters.Add(new SqlParameter("address", address));
            cmd.Parameters.Add(new SqlParameter("datetime", datetime));
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public List<string> getActivities()
        {
            openConnection();
            string query = "SELECT activityname FROM Activity";
            SqlCommand sqlcmd = new SqlCommand(query, conn);

            List<string> activitylist = new List<string>();
            int i = 0;
            using (sqlcmd)
            {
                using (var reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        activitylist.Add(reader[i].ToString());
                        i++;
                    }
                }
            }

            return activitylist;
        }
    }
}
