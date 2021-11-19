using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAddressInfoDAL
    {
        List<AddressInfoDTO> GetAll();
        AddressInfoDTO GetByID(int ID);
        void Add(AddressInfoDTO address);
        void ReadDB();
    }
}
