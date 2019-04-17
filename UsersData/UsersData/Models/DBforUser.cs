using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace UsersData.Models
{
    public class DBforUser
    {
        private string conectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\InnoUser10\Documents\MyUserData.mdf;Integrated Security=True;Connect Timeout=30";
        public string ConString
        {
            get
            {
                return conectionString;
            }
            private set
            {
                value = conectionString;
            }
        }
        public DBforUser()
        {

        }

        public void Insert(Users us)
        {
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                string insertQuery = @"INSERT INTO [Table] VALUES(@Id,@Name,@LastName,@Solary)";
                using (SqlCommand command = new SqlCommand(insertQuery, connection))
                {
                    connection.Open();
                    command.Parameters.Add(new SqlParameter("Id", us.Id));
                    command.Parameters.Add(new SqlParameter("Name", us.Name));
                    command.Parameters.Add(new SqlParameter("LastName", us.Lastname));
                    command.Parameters.Add(new SqlParameter("Solary", us.Solary));
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        public List<Users> Select(Users us)
        {
            using (SqlConnection connection = new SqlConnection(conectionString))
            {
                List<Users> users = new List<Users>();
                string selectQuery = @"SELECT Id, Name, LastName, Solary FROM[Table]";
                connection.Open();
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        us = new Users();
                        us.Id = int.Parse(reader[0].ToString());
                        us.Name = reader[1].ToString();
                        us.Lastname = reader[2].ToString();
                        us.Solary = int.Parse(reader[3].ToString());
                        users.Add(us);
                    }




                }
                return users;
            }

        }
        public void Update(Users us)
        {
        }
        public void Delete(int id)
        {
            string deleteQuery = @"DELETE FROM [Table] WHERE Id='" + id + "'";
            using (SqlConnection connection = new SqlConnection(conectionString))
            {

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
