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


        public string InfoString()
        {
            return $"Discount: {Discount}";
        }
    }
}
