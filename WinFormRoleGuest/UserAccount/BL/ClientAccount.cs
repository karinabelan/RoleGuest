using DAL.Interface;
using DTO;
using System.Collections.Generic;
using WinFormRoleGuest.Interface;

namespace WinFormRoleGuest.BL
{
    public class ClientAccount : IClientAccount
    {
        readonly private IClientDAL client_1;
        public ClientAccount(IClientDAL client)
        {
            client_1 = client;
        }
        public void Add(ClientDTO user)
        {
            client_1.Add(user);
        }

        public void Change(string newpass, string log, string fn)
        {
           client_1.Change(newpass,log,fn);
        }

        public List<ClientDTO> GetAll()
        {
            return client_1.GetAll();
        }

        public ClientDTO GetByID(int ID)
        {
           return client_1.GetByID(ID);
        }

        public void ReadDB()
        {
            client_1.ReadDB();
        }
    }
}
