using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormRoleGuest.Interface
{
    public interface IAddressInfoAccount
    {
        List<AddressInfoDTO> GetAll();
        AddressInfoDTO GetByID(int ID);
        void Add(AddressInfoDTO address);
        void ReadDB();
    }
}
