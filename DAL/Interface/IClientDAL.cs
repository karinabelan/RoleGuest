using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IClientDAL
    {
        List<ClientDTO> GetAll();
        ClientDTO GetByID(int ID);
        void Add(ClientDTO user);
        void Change( string newpass, string log, string fn);
        ClientDTO GetObj(string IdT);
        void ReadDB();
    }
}
