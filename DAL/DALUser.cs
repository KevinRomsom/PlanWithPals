using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALUser
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
        public string GetEmailaddress(string modelemailaddress)
        {
            openConnection();
            string query = "SELECT emailaddress FROM [UserTable] WHERE emailaddress=@modelemailaddress";
            SqlCommand sqlcmd = new SqlCommand(query, conn);
            sqlcmd.Parameters.AddWithValue("@modelemailaddress", modelemailaddress);

            string emailaddress = "";
            using (sqlcmd)
            {
                using (var reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        emailaddress = reader[0].ToString();
                    }
                }
            }
            conn.Close();
            return emailaddress;
        }

        public string GetPassword(string modelpassword)
        {
            openConnection();
            string passwordquery = "SELECT password FROM [UserTable] WHERE password=@modelpassword";
            SqlCommand sqlcmd = new SqlCommand(passwordquery, conn);
            sqlcmd.Parameters.AddWithValue("@modelpassword", modelpassword);

            string password = "";
            using (sqlcmd)
            {
                using (var reader = sqlcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        password = reader[0].ToString();
                    }
                }
            }
            conn.Close();

            return password;
        }

        public void InsertIntoDB(string name, string surname, string emailaddress, string password, string address, string city)
        {
            openConnection();
            string query = "INSERT INTO [UserTable] ( name, surname, emailaddress, password, address, city) " +
                "VALUES (@name, @surname, @emailaddress, @password, @address, @city);";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.Add(new SqlParameter("name", name));
            cmd.Parameters.Add(new SqlParameter("surname", surname));
            cmd.Parameters.Add(new SqlParameter("emailaddress", emailaddress));
            cmd.Parameters.Add(new SqlParameter("password", password));
            cmd.Parameters.Add(new SqlParameter("address", address));
            cmd.Parameters.Add(new SqlParameter("city", city));
            cmd.ExecuteNonQuery();
            
            conn.Close();
        }

        
    }

   

}
