using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IClientDAL<T>
    {
        List<T> GetAll();
        T GetByID(int ID);
        void Add(T u);
        void Change( string newValue, string newValue2, string newValue3);
        void ReadDB();
    }
}
