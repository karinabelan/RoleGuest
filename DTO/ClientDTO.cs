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
        public DateTime RowInsertTime { get; set; }
        public DateTime RowUpdateTime { get; set; }


        public void ChangePassword(string newPass)
        {
            Password = newPass;
        }
        //public ClientDTO(string Login, string Password, string FirstName, string LastName, int InfoId, DateTime RowInsertTime, DateTime RowUpdateTime, int PersonId = 0)
        //{
        //    this.FirstName = FirstName;
        //    this.LastName = LastName;
        //    this.Login = Login;
        //    this.Password = Password;
        //    this.InfoID = InfoId;
        //    this.PersonID= PersonId;
        //    this.RowInsertTime = RowInsertTime;
        //    this.RowUpdateTime = RowUpdateTime;
        //}
        public string InfoString()
        {
            return $"PersonID: {PersonID}\tLogin: {Login}\tPassword: {Password}";
        }

        public void Add(ClientDTO clients)
        {
            throw new NotImplementedException();
        }
    }
}
