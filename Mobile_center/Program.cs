using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Mobile_center
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static formMain formMain;
        public static formAuthorization formAuthorization;
        public static formProducts formProducts;
        public static formCustomers formCustomers;
        public static formStaff formStaff;
        public static formOrders formOrders;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            formAuthorization = new formAuthorization();
            formMain = new formMain();

            DataGridManager manager = new DataGridManager();

            formProducts    = new formProducts(manager);
            formOrders = new formOrders(manager);
            formCustomers   = new formCustomers(manager);
            formStaff       = new formStaff(manager);
            
            Application.Run(formAuthorization);
        }
    }
}
