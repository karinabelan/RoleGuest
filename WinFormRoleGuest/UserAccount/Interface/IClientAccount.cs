using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormRoleGuest.Account;

namespace WinFormRoleGuest.Interface
{
    public interface IClientAccount
    {
        List<ClientDTO> GetAll();
        ClientDTO GetByID(int ID);
        void Add(ClientDTO user);
        void Change(string newpass, string log, string fn);
        void ReadDB();
    }
}
