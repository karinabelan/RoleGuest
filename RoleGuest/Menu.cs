using DAL.ADO;
using DAL.Interface;
using DTO;
using System;

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
                                    foreach(var inf in info.GetAll())
                                    {
                                        if (temp.InfoID == inf.InfoID)
                                        {
                                            info.Change(Convert.ToString(inf.RowInsertTime), Convert.ToString(inf.AddressID), "");
                                        }
                                    }
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
                                                Console.WriteLine("Change password? ");
                                                while (true)
                                                {
                                                    bool isExit2 = false;
                                                    Console.WriteLine(@" 
1.Yes
2.No

");
                                                    string userInput2 = Console.ReadLine();
                                                    switch (userInput2)
                                                    {
                                                        case "1":
                                                            {
                                                                //Console.Write("\nID:");
                                                                //int index1 = Convert.ToInt32(Console.ReadLine());
                                                                Console.Write("\nLogin:");
                                                                string login1 = Console.ReadLine();
                                                                Console.Write("\nFirstName:");
                                                                string firstName1 = Console.ReadLine();


                                                                bool isLogin1 = false;
                                                                foreach (ClientDTO temp in client.GetAll())
                                                                {
                                                                    if (temp.Login == login1 && temp.FirstName == firstName1)
                                                                    {
                                                                        isLogin1 = true;
                                                                    }
                                                                }
                                                                if (isLogin1)
                                                                {
                                                                    Console.Write("\nInput new password:");
                                                                    string name1 = Console.ReadLine();
                                                                    client.Change( name1, login1, firstName1);
                                                                    Console.WriteLine("sucessfully changed!\n");
                                                                    Console.ReadKey();
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Wrong login or first name\n");
                                                                }
                                                                    
                                                            }
                                                            isExit2 = true;
                                                            break;
                                                        case "2":
                                                            isExit2 = true;
                                                            break;
                                                        default:
                                                            {
                                                                Console.WriteLine("Error! Try again!");
                                                            }
                                                            break;
                                                    };
                                                    if (isExit2)
                                                        break;
                                                }                                             
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
                            bool Existed = false;
                            foreach(var cl in client.GetAll())
                            {
                                if (cl.Login == LoginStr)
                                {
                                    Existed = true;
                                }
                            }
                            if (Existed == true)
                            {
                                Console.WriteLine("Error");
                            }
                            else
                            {
                                Console.Write("\nPassword:");
                                string PasswordStr = Console.ReadLine();
                                Console.Write("\nCountry:");
                                string CountryStr = Console.ReadLine();
                                Console.Write("\nCity:");
                                string CityStr = Console.ReadLine();
                                //Console.Write("\nInfoID:");
                                //int InfoIDStr = Convert.ToInt32(Console.ReadLine());
                                //Console.Write("\nAddressID:");
                                //int AddressIDStr = Convert.ToInt32(Console.ReadLine());
                                int countOfVisitStr = 1;
                                int discountStr = 1;

                                AddressInfoDTO addressInfoDTO = new AddressInfoDTO();
                                addressInfoDTO.Country = CountryStr;
                                addressInfoDTO.City = CityStr;
                                DateTime qurentTime = DateTime.Now;
                                addressInfoDTO.RowInsertTime = qurentTime;

                                addressInfoDTO.RowUpdateTime = DateTime.Now;
                                addressInfo.Add(addressInfoDTO);
                                addressInfo.ReadDB();
                                int qurentID = 0;
                                foreach (var address in addressInfo.GetAll())
                                {
                                    if (Convert.ToString(qurentTime) == Convert.ToString(address.RowInsertTime))
                                    {
                                        qurentID = address.AddressID;
                                    }
                                }

                                InfoDTO infoDTO = new InfoDTO();
                                infoDTO.CountOfVisit = countOfVisitStr;
                                infoDTO.Discount = discountStr;
                                DateTime qurent1Time = DateTime.Now;
                                infoDTO.RowInsertTime = qurent1Time;
                                infoDTO.RowUpdateTime = DateTime.Now;

                                //infoDTO.InfoID =InfoIDStr;
                                infoDTO.AddressID = qurentID;
                                info.Add(infoDTO);
                                info.ReadDB();
                                int qurent1ID = 0;
                                foreach (var inforn in info.GetAll())
                                {
                                    if (Convert.ToString(qurent1Time) == Convert.ToString(inforn.RowInsertTime))
                                    {
                                        qurent1ID = inforn.InfoID;
                                    }
                                }

                                ClientDTO clients = new ClientDTO();
                                clients.FirstName = FirstNameStr;
                                clients.LastName = LastNameStr;
                                clients.Login = LoginStr;
                                clients.Password = PasswordStr;
                                clients.InfoID = qurent1ID;

                                clients.RowInsertTime = DateTime.Now;
                                clients.RowUpdateTime = DateTime.Now;

                                client.Add(clients);
                                Console.WriteLine("Account created! Return and log in!\n");
                            }
                            Console.ReadKey();
                        }
                        break;
                    case "3":
                        {
                        //    /////////add  data verification
                        //    Console.WriteLine("Change password: ");

                        //    Console.Write("\nID:");
                        //    int index = Convert.ToInt32(Console.ReadLine());
                        //    Console.Write("\nLogin:");
                        //    string login = Console.ReadLine();
                        //    Console.Write("\nFirstName:");
                        //    string firstName = Console.ReadLine();

                        //    Console.Write("\nInput new password:");
                        //    string name = Console.ReadLine();
                        //    client.Change(index, name, firstName,);

                        //    Console.WriteLine("sucessfully changed!\n");
                        //    Console.ReadKey();
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
