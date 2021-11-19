using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormRoleGuest.Interface
{
    public interface IInfoAccount
    {
        List<InfoDTO> GetAll();
        InfoDTO GetByID(int ID);
        void Add(InfoDTO information);
        void Change(string newValue, string newValue2);
        void ReadDB();
    }
}
