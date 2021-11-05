using DAL.ADO;
using DAL.Interface;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoleGuest
{
    class Menu
    {
        IClientDAL<ClientDTO> client;
        IClientDAL<InfoDTO> info;
        IClientDAL<AddressInfoDTO> addressInfo;

        public Menu()
        {
            client = new ClientADO();
            info = new InfoADO();
            addressInfo = new AddressInfoADO();

        }
        public void ShowMenu()
        {
            while (true)
            {
                bool isExit = false;
                Console.WriteLine(@"
_______Welcome_______
Select option:
1.Log in
2.Sign up
3.Forgot your password?
0. Exit.
");

                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        {
                            string loginUser;
                            Console.WriteLine("Login: ");
                            loginUser = Console.ReadLine();
                            string passUser;
                            Console.WriteLine("Password: ");
                            passUser = Console.ReadLine();
                            bool isLogin = false;
                            foreach (ClientDTO temp in client.GetAll())
                            {
                                if (temp.Password == passUser && temp.Login == loginUser)
                                {
                                    isLogin = true;
                                }

                            }
                            if (isLogin)
                            {

                                Console.WriteLine("@Welcome to our store" +
                                    "1.Menu" +
                                    "2.Settings");
                                    //all function with logined person

                            }
                            else
                            {
                                Console.WriteLine("Incorect password or login.\n Try again!");
                            }
                        }
                        break;
                    case "2":
                        Console.Write("\nFirstName:");
                        string FirstNameStr = Console.ReadLine();
                        Console.Write("\nLastName:");
                        string LastNameStr = Console.ReadLine();
                        Console.Write("\nLogin:");
                        string LoginStr = Console.ReadLine();
                        Console.Write("\nPassword:");
                        string PasswordStr = Console.ReadLine();
                        Console.Write("\nCountry:");
                        string CountryStr = Console.ReadLine();
                        Console.Write("\nCity:");
                        string CityStr = Console.ReadLine();
                        //Console.Write("\nID:");
                        //int IDStr = Convert.ToInt32(Console.ReadLine());

                        InfoDTO infoDTO = new InfoDTO();


                        AddressInfoDTO addressInfoDTO = new AddressInfoDTO();
                        addressInfoDTO.Country = CountryStr;
                        addressInfoDTO.City = CityStr;
                        addressInfo.Add(addressInfoDTO);
                        //infoDTO.InfoID =IDStr;
                        infoDTO.AddressID = addressInfoDTO.AddressID;
                        info.Add(infoDTO);
                        ClientDTO clients = new ClientDTO();

                        clients.FirstName = FirstNameStr;
                        clients.LastName = LastNameStr;
                        clients.Login = LoginStr;
                        clients.Password = PasswordStr;
                        clients.InfoID = infoDTO.InfoID;
                        client.Add(clients);
                        Console.WriteLine("Return and log in!\n");
                        Console.ReadKey();
                        break;
                    case "3":

                        break;
                    case "0":
                        isExit = true;
                        break;

                    default:
                        {
                            Console.WriteLine("Error! Try again!");
                        }
                        break;
                }

                if (isExit)
                    break;
            }
        }
    }
}
