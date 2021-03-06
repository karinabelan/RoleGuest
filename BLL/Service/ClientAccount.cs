using BLL.Interface;
using DAL.Interface;
using DTO;
using System.Collections.Generic;

namespace WinFormRoleGuest.BLL
{
    public class ClientAccount : IClientAccount
    {
        readonly private IClientDAL _clients;
        public ClientAccount(IClientDAL clients)
        {
            _clients = clients;
        }
        public void Add(ClientDTO user)
        {
            _clients.Add(user);
        }

        public void Change(string newpass, string log, string fn)
        {
           _clients.Change(newpass,log,fn);
        }

        public List<ClientDTO> GetAll()
        {
            return _clients.GetAll();
        }

        public ClientDTO GetByID(int ID)
        {
           return _clients.GetByID(ID);
        }

        public ClientDTO GetObj(string IdT)
        {
            return _clients.GetObj(IdT);
        }

        public void ReadDB()
        {
            _clients.ReadDB();
        }
    }
}
