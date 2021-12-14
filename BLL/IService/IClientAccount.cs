using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.Interface
{
    public interface IClientAccount
    {
        List<ClientDTO> GetAll();
        ClientDTO GetByID(int ID);
        void Add(ClientDTO user);
        void Change(string newpass, string log, string fn);
        ClientDTO GetObj(string IdT);
        void ReadDB();
    }
}
