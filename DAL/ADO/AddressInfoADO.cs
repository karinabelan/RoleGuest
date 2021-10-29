using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ADO
{
    public class AddressInfoADO : IClientDAL<AddressInfoDTO>
    {
        List<AddressInfoDTO> addressInfo;
        private string connStr = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=Guest;Integrated Security=True;";
        public AddressInfoADO()
        {
            addressInfo = new List<AddressInfoDTO>();
            ReadDB();
        }
        private void ReadDB()
        {
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        using (SqlCommand comm = conn.CreateCommand())
                        {
                            conn.Open();
                            comm.CommandText = "SELECT [AddressID],[Country],[City]FROM [RoleGuest].[dbo].[AddressInfo] ";

                            SqlDataReader reader = comm.ExecuteReader();
                            while (reader.Read())
                            {
                                addressInfo.Add(new AddressInfoDTO
                                {
                                    AddressID = (int)reader["AddressID"],
                                    Country = reader["Country"].ToString(),
                                    City = reader["City"].ToString()
                                });
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }
        public List<AddressInfoDTO> GetAll()
        {
            return addressInfo;
        }

        public void Add(AddressInfoDTO u)
        {
            addressInfo.Add(u);

            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "INSERT INTO AddressInfo(Country, City) VALUES(@country, @city)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@country", u.Country);
                    comm.Parameters.AddWithValue("@city", u.City);
                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }
        public void Change(int ID, string newValue)
        {
            throw new NotImplementedException();
        }

        public AddressInfoDTO GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
