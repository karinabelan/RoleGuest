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
    public class ClientADO : IClientDAL
    { 
        List<ClientDTO> clients;
        private string conn = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=RoleGuest;Integrated Security=True";
        public ClientADO()
        {
            clients = new List<ClientDTO>();
            ReadDB();
        }
        public void ReadDB()
        {
            {
                try
                {
                    clients.Clear();
                    using (SqlConnection conn = new SqlConnection(this.conn))
                    using (SqlCommand comm = conn.CreateCommand())
                    {
                        comm.CommandText = "SELECT [PersonID],[InfoID],[Login],[Password],[FirstName],[LastName],[RowInsertTime],[RowUpdateTime] FROM[RoleGuest].[dbo].[Client] ";
                        conn.Open();
                        SqlDataReader reader = comm.ExecuteReader();
                        //var users = new List<UserDTO>();
                        while (reader.Read())
                        {
                            clients.Add(new ClientDTO
                            {
                                PersonID = (int)reader["PersonID"],
                                InfoID = (int)reader["InfoID"],
                                Login = reader["Login"].ToString(),
                                Password = reader["Password"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                RowInsertTime = (DateTime)reader["RowInsertTime"],
                                RowUpdateTime = (DateTime)reader["RowUpdateTime"]
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
            return clients;
        }
        public void Add(ClientDTO user)
        {
            clients.Add(user);

            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Client(Login,Password,FirstName,LastName,InfoID, RowInsertTime,RowUpdateTime) values (@login,@password,@FN,@LN,@infoID, @insertTime, @updateTime)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@login", user.Login);
                    comm.Parameters.AddWithValue("@password", user.Password);
                    comm.Parameters.AddWithValue("@FN", user.FirstName);
                    comm.Parameters.AddWithValue("@LN", user.LastName);
                    comm.Parameters.AddWithValue("@infoID", user.InfoID);
                    comm.Parameters.AddWithValue("@insertTime", user.RowInsertTime);
                    comm.Parameters.AddWithValue("@updateTime", user.RowUpdateTime);

                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }

        public void Change( string newpass, string log, string fn)
        {
            //var clientTemp = GetByID(ID);
            foreach (ClientDTO temp in clients)
            {
                if (temp.Login == log && temp.FirstName== fn)
                {
                    temp.ChangePassword(newpass);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Client set Password=@newPassword where FirstName=@FN and Login=@login";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newPassword", newpass);
                    comm.Parameters.AddWithValue("@FN", fn);
                    comm.Parameters.AddWithValue("@login", log);
                    int row = comm.ExecuteNonQuery();
                }
            }
        }

        public ClientDTO GetByID(int ID)
        {
            int index = 0;
            for (int i = 0; i < clients.Count; i++)
            {
                if (clients[i].PersonID == ID)
                {
                    index = i;
                }
            }
            return clients[index];
        }

        public ClientDTO GetObj(string IdT)
        {
            var tempObj = clients.Where(x => x.Login == IdT).SingleOrDefault();

            return tempObj;
        }
    }
}
