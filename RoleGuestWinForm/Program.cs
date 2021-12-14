using BLL.Interface;
using DAL.ADO;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using WinFormRoleGuest.BLL;

namespace RoleGuestWinForm
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        public static UnityContainer Container;
        [STAThread]
        static void Main()
        {
            ConfigureUnity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<LoginForm>());
        }
        static private void ConfigureUnity()
        {
            Container = new UnityContainer();
            Container.RegisterType<IAddressInfoAccount, AddressInfoAccount>()
                     .RegisterType<IClientAccount, ClientAccount>()
                     .RegisterType<IInfoAccount, InfoAccount>()
                     .RegisterType<IAddressInfoDAL, AddressInfoADO>()
                     .RegisterType<IClientDAL, ClientADO>()
                     .RegisterType<IInfoDAL, InfoADO>();

        }
    }
}
