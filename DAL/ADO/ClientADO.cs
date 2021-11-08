using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class ClientADO : IClientDAL<ClientDTO>
    {
        List<ClientDTO> client;
        private string conn = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=RoleGuest;Integrated Security=True";
        public ClientADO()
        {
            client = new List<ClientDTO>();
            ReadDB();
        }
        private void ReadDB()
        {
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(this.conn))
                    using (SqlCommand comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT TOP (1000) [PersonID],[InfoID],[Login],[Password],[FirstName],[LastName],[RowInsertTime],[RowUpdateTime] FROM[RoleGuest].[dbo].[Client] ";
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        //var users = new List<UserDTO>();
                        while (reader.Read())
                        {
                            client.Add(new ClientDTO
                            {
                                PersonID = (int)reader["PersonID"],
                                InfoID = (int)reader["InfoID"],
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString()
                                //RowInsertTime =(DateTime) reader["RowInsertTime"],
                                //RowUpdateTime = (DateTime)reader["RowUpdateTime"]
                        });
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }
        public List<ClientDTO> GetAll()
        {
            return client;
        }
        public void Add(ClientDTO u)
        {
            client.Add(u);

            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Client(Login,Password,FirstName,LastName,InfoID, RowInsertTime,RowUpdateTime) values (@login,@password,@FN,@LN,@infoID, @insertTime, @updateTime)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@login", u.Login);
                    comm.Parameters.AddWithValue("@password", u.Password);
                    comm.Parameters.AddWithValue("@FN", u.FirstName);
                    comm.Parameters.AddWithValue("@LN", u.LastName);
                    comm.Parameters.AddWithValue("@infoID", u.InfoID);
                    comm.Parameters.AddWithValue("@insertTime", u.RowInsertTime);
                    comm.Parameters.AddWithValue("@updateTime", u.RowUpdateTime);

                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }

        public void Change(int ID, string newValue, string newValue2, string newValue3)
        {
            var clientTemp = GetByID(ID);
            foreach (ClientDTO temp in client)
            {
                if (temp.Password == clientTemp.Password)
                {
                    temp.ChangePassword(newValue);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Client set Password=@newPassword where FirstName=@FN and Login=@login";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newPassword", newValue);
                    comm.Parameters.AddWithValue("@FN", clientTemp.FirstName);
                    comm.Parameters.AddWithValue("@login", clientTemp.Login);
                    int row = comm.ExecuteNonQuery();
                }
            }
        }

        public ClientDTO GetByID(int ID)
        {
            int index = 0;
            for (int i = 0; i < client.Count; i++)
            {
                if (client[i].PersonID == ID)
                {
                    index = i;
                }
            }
            return client[index];
        }
    }
}
