using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest.BL
{
    public class InfoAccount : IInfoAccount
    {
        readonly private IInfoDAL info_1;
        public InfoAccount(IInfoDAL info)
        {
            info_1 = info;
        }
        public void Add(InfoDTO information)
        {
            info_1.Add(information);
        }

        public void Change(string newValue, string newValue2)
        {
            info_1.Change(newValue, newValue2);
        }

        public List<InfoDTO> GetAll()
        {
            return info_1.GetAll();
        }

        public InfoDTO GetByID(int ID)
        {
            return info_1.GetByID(ID);
        }
        public void ReadDB()
        {
            info_1.ReadDB();
        }
    }
}
