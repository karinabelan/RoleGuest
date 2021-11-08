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
        private string connStr = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=RoleGuest;Integrated Security=True";
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
                            comm.CommandText = "SELECT [AddressID],[Country],[City],[RowInsertTime],[RowInsertTime] FROM [RoleGuest].[dbo].[AddressInfo] ";

                            SqlDataReader reader = comm.ExecuteReader();
                            while (reader.Read())
                            {
                                addressInfo.Add(new AddressInfoDTO
                                {
                                    AddressID = (int)reader["AddressID"],
                                    Country = reader["Country"].ToString(),
                                    City = reader["City"].ToString()
                                    //RowInsertTime = (DateTime)reader["RowInsertTime"],
                                    //RowUpdateTime = (DateTime)reader["RowUpdateTime"]
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
                    comm.CommandText = "INSERT INTO AddressInfo(Country, City, RowInsertTime,RowUpdateTime) VALUES(@country, @city, @insertTime, @updateTime)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@country", u.Country);
                    comm.Parameters.AddWithValue("@city", u.City);
                    comm.Parameters.AddWithValue("@insertTime", u.RowInsertTime);
                    comm.Parameters.AddWithValue("@updateTime", u.RowUpdateTime);
                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }

        public void Change(int ID, string newValue, string newValue2, string newValue3)
        {
            throw new NotImplementedException();
        }

        public AddressInfoDTO GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
