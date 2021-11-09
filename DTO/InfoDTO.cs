using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InfoDTO
    {
        public int InfoID { get; set; }
        public int CountOfVisit { get; set; } = 0;
        public int Discount { get; set; } = 0;
        public int AddressID { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }

        public void ChangeNumOfVisit()
        {
            CountOfVisit += 1;
        }
        //public InfoDTO(int CountOfVisit, int Discount, int AddressId, DateTime RowInsertTime, DateTime RowUpdateTime, int InfoId = 0)
        //{
        //    this.CountOfVisit = CountOfVisit;
        //    this.Discount = Discount;
        //    this.AddressID = AddressId;
        //    this.InfoID = InfoId;
        //    this.RowInsertTime = RowInsertTime;
        //    this.RowUpdateTime = RowUpdateTime;
        //}
        public string InfoString()
        {
            return $"Discount: {Discount}";
        }
    }
}
