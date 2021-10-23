using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ClientDTO
    {
        public int PersonID { get; set; }
        public int InfoID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public void ChangePassword(string newPass)
        {
            Password = newPass;
        }
        public string InfoString()
        {
            return $"PersonID: {PersonID}\tLogin: {Login}\tPassword: {Password}";
        }
    }
}
