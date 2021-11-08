using DAL.Interface;
using DTO;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Tests
{
    
    [TestFixture]

    public class ClientDalTests
    {
        IClientDAL<ClientDTO> client;
        [Test]
        public void Test_GetByID()
        {
            ClientDTO temp = new ClientDTO();
            string firstName = "Mas";
            temp.FirstName = firstName;
            temp.PersonID = 3;//current

            ClientDTO exepObj = client.GetByID(temp.PersonID);
            Assert.AreEqual(exepObj.PersonID, temp.PersonID);
        }
    }
    }
}
