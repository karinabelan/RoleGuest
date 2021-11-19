using DAL.Interface;
using DTO;
using System.Collections.Generic;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest.BL

{
    public class AddressInfoAccount : IAddressInfoAccount
    {
        readonly private IAddressInfoDAL addressInfo_1;
        public AddressInfoAccount(IAddressInfoDAL addressInfo)
        {
            addressInfo_1 = addressInfo;
        }
        public void Add(AddressInfoDTO address)
        {
            addressInfo_1.Add(address);
        }

        public List<AddressInfoDTO> GetAll()
        {
            return addressInfo_1.GetAll();
        }

        public AddressInfoDTO GetByID(int ID)
        {
            return addressInfo_1.GetByID(ID);
        }

        public void ReadDB()
        {
            addressInfo_1.ReadDB();
        }
    }
}
