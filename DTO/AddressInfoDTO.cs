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

        public string InfoString()
        {
            return $"Country: {Country}\tSity: {City}";
        }
    }
}
