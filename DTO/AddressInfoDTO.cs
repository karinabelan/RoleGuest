using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AddressInfoDTO
    {
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }


        //public AddressInfoDTO(string Country, string City, DateTime RowInsertTime, DateTime RowUpdateTime, int AddressId = 0)
        //{
        //    this.Country = Country;
        //    this.City = City;
        //    this.AddressID = AddressId;
        //    this.RowInsertTime = RowInsertTime;
        //    this.RowUpdateTime = RowUpdateTime;
        //}
        public string InfoString()
        {
            return $"Country: {Country}\tSity: {City}";
        }
    }
}
