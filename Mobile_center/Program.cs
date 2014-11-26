using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MobileCenter
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>

        public static mainForm mainForm;
        public static authorizationForm authorizationForm;
        public static productsForm productsForm;
        public static servicesForm servicesForm;
        public static customersForm customersForm;
        public static staffForm staffForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainForm = new MobileCenter.mainForm();
            authorizationForm = new MobileCenter.authorizationForm();
            productsForm = new MobileCenter.productsForm();
            servicesForm = new MobileCenter.servicesForm();
            customersForm = new MobileCenter.customersForm();
            staffForm = new MobileCenter.staffForm();
            Application.Run(authorizationForm);
        }
    }
}
