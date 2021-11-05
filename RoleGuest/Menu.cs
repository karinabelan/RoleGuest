﻿using DAL.ADO;
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
                                while (true)
                                {
                                    bool isExit1 = false;
                                    Console.WriteLine(@" 
________________Welcome to our store__________________    
Select option:
1.Menu                                      
2.Settings                                       
0.Log out

");
                                    string userInput1 = Console.ReadLine();
                                    switch (userInput1)
                                    {
                                        case "1":
                                            {

                                            }
                                            break;
                                        case "2":
                                            {
                                                /////////add  data verification
                                                Console.WriteLine("Change password: ");

                                                Console.Write("\nID:");
                                                int index1 = Convert.ToInt32(Console.ReadLine());
                                                Console.Write("\nLogin:");
                                                string login1 = Console.ReadLine();
                                                Console.Write("\nFirstName:");
                                                string firstName1 = Console.ReadLine();

                                                Console.Write("\nInput new password:");
                                                string name1 = Console.ReadLine();
                                                client.Change(index1, name1, firstName1);

                                                Console.WriteLine("sucessfully changed!\n");
                                                Console.ReadKey();
                                            }

                                            break;
                                        case "0":
                                            isExit1 = true;
                                            break;
                                        default:
                                            {
                                                Console.WriteLine("Error! Try again!");
                                            }
                                            break;
                                    }
                                    if (isExit1)
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Incorect password or login.\n Try again!");
                            }
                        }
                        break;
                    case "2":
                        {
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
                            Console.WriteLine("Account created! Return and log in!\n");
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        {
                            /////////add  data verification
                            Console.WriteLine("Change password: ");

                            Console.Write("\nID:");
                            int index = Convert.ToInt32(Console.ReadLine());
                            Console.Write("\nLogin:");
                            string login = Console.ReadLine();
                            Console.Write("\nFirstName:");
                            string firstName = Console.ReadLine();

                            Console.Write("\nInput new password:");
                            string name = Console.ReadLine();
                            client.Change(index, name, firstName);

                            Console.WriteLine("sucessfully changed!\n");
                            Console.ReadKey();
                        }
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
