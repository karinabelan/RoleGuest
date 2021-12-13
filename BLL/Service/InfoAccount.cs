using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest.BLL
{
    public class InfoAccount : IInfoAccount
    {
        readonly private IInfoDAL _infos;
        public InfoAccount(IInfoDAL infos)
        {
            _infos = infos;
        }
        public void Add(InfoDTO information)
        {
            _infos.Add(information);
        }

        public void Change(string newValue, string newValue2)
        {
            _infos.Change(newValue, newValue2);
        }

        public List<InfoDTO> GetAll()
        {
            return _infos.GetAll();
        }

        public InfoDTO GetByID(int ID)
        {
            return _infos.GetByID(ID);
        }
        public void ReadDB()
        {
            _infos.ReadDB();
        }
    }
}
