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
    public class InfoADO : IClientDAL<InfoDTO>
    {
        List<InfoDTO> info;
        private string conn = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=RoleGuest;Integrated Security=True";
        public InfoADO()
        {
            info = new List<InfoDTO>();
            ReadDB();
        }
        private void ReadDB()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(this.conn))
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT  [InfoID],[CountOfVisit],[Discount],[AddressID] FROM [RoleGuest].[dbo].[Info] ";
                    conn.Open();
                    SqlDataReader reader = comm.ExecuteReader();

                    while (reader.Read())
                    {
                        info.Add(new InfoDTO
                        {
                            InfoID = (int)reader["InfoID"],
                            CountOfVisit = (int)reader["CountOfVisit"],
                            Discount = (int)reader["Discount"],
                            AddressID = (int)reader["AddressID"],
                        });
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
        public List<InfoDTO> GetAll()
        {
            return info;
        }
        public void Add(InfoDTO u)
        {
            info.Add(u);

            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "INSERT INTO Info(CountOfVisit,Discount,AddressID) VALUES(@COV,@discount,@adrID)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@COV", u.CountOfVisit);
                    comm.Parameters.AddWithValue("@discount", u.Discount);
                    comm.Parameters.AddWithValue("@adrID", u.AddressID);
                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }

        public void Change(int ID, string newValue, string newValue2)
        {
            throw new NotImplementedException();
        }
        public InfoDTO GetByID(int ID)
        {
            int index = 0;
            for (int i = 0; i < info.Count; i++)
            {
                if (info[i].InfoID == ID)
                {
                    index = i;
                }
            }
            return info[index];
        }
    }
}
