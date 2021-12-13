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
    public class AddressInfoADO : IAddressInfoDAL
    {
        List<AddressInfoDTO> addressInfos;
        private string connStr = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=RoleGuest;Integrated Security=True";
        public AddressInfoADO()
        {
            addressInfos = new List<AddressInfoDTO>();
            ReadDB();
        }
        public void ReadDB()
        {
            {
                try
                {
                    addressInfos.Clear();

                    using (SqlConnection conn = new SqlConnection(connStr))
 
                    {
                        using (SqlCommand comm = conn.CreateCommand())
                        {
                            conn.Open();
                            comm.CommandText = "SELECT [AddressID],[Country],[City],[RowInsertTime],[RowUpdateTime] FROM [RoleGuest].[dbo].[AddressInfo] ";

                            SqlDataReader reader = comm.ExecuteReader();
                            while (reader.Read())
                            {
                                addressInfos.Add(new AddressInfoDTO
                                {
                                    AddressID = (int)reader["AddressID"],
                                    Country = reader["Country"].ToString(),
                                    City = reader["City"].ToString(),
                                    RowInsertTime = (DateTime)reader["RowInsertTime"],
                                    RowUpdateTime = (DateTime)reader["RowUpdateTime"]
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
            return addressInfos;
        }

        public void Add(AddressInfoDTO address)
        {
            addressInfos.Add(address);

            using (SqlConnection connectionSql = new SqlConnection(connStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "INSERT INTO AddressInfo(Country, City, RowInsertTime,RowUpdateTime) VALUES(@country, @city, @insertTime, @updateTime)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@country", address.Country);
                    comm.Parameters.AddWithValue("@city", address.City);
                    comm.Parameters.AddWithValue("@insertTime", address.RowInsertTime);
                    comm.Parameters.AddWithValue("@updateTime", address.RowUpdateTime);
                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }

        public AddressInfoDTO GetByID(int ID)
        {
            int index = 0;
            for (int i = 0; i < addressInfos.Count; i++)
            {
                if (addressInfos[i].AddressID == ID)
                {
                    index = i;
                }
            }
            return addressInfos[index];
        }
    }
}
