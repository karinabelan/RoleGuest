using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IInfoDAL
    {
        List<InfoDTO> GetAll();
        InfoDTO GetByID(int ID);
        void Add(InfoDTO information);
        void Change(string newValue, string newValue2);
        void ReadDB();
    }
}
