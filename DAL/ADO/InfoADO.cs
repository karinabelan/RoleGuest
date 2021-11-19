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
    public class InfoADO : IInfoDAL
    {
        List<InfoDTO> info;
        private string conn = "Data Source=DESKTOP-2E4L5Q6;Initial Catalog=RoleGuest;Integrated Security=True";
        public InfoADO()
        {
            info = new List<InfoDTO>();
            ReadDB();
        }
        public void ReadDB()
        {
            try
            {
                info.Clear();
                using (SqlConnection conn = new SqlConnection(this.conn))
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = "SELECT  [InfoID],[CountOfVisit],[Discount],[AddressID],[RowInsertTime],[RowUpdateTime] FROM [RoleGuest].[dbo].[Info] ";
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
        public List<InfoDTO> GetAll()
        {
            return info;
        }
        public void Add(InfoDTO information)
        {
            info.Add(information);

            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "INSERT INTO Info(CountOfVisit,Discount,AddressID, RowInsertTime,RowUpdateTime) VALUES(@COV,@discount,@adrID, @insertTime, @updateTime)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@COV", information.CountOfVisit);
                    comm.Parameters.AddWithValue("@discount", information.Discount);
                    comm.Parameters.AddWithValue("@adrID", information.AddressID);
                    comm.Parameters.AddWithValue("@insertTime", information.RowInsertTime);
                    comm.Parameters.AddWithValue("@updateTime", information.RowUpdateTime);
                    comm.ExecuteNonQuery();
                    //bool T = true;
                }
            }
        }

        public void Change(string newValue, string newValue2)//new-qurrent1time, new2-adressid
        {
            int visitCur = 0;
            foreach (InfoDTO temp in info)
            {
                if (Convert.ToString(temp.RowInsertTime) == newValue && newValue2== Convert.ToString(temp.AddressID))
                {
                    temp.ChangeNumOfVisit();
                    visitCur = temp.CountOfVisit;
                    //Idcur = temp.InfoID;
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(conn))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Info set CountOfVisit=@visit where AddressID=@add";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@visit", visitCur);
                    
                    comm.Parameters.AddWithValue("@add", newValue2);
                    int row = comm.ExecuteNonQuery();
                }
            }
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
