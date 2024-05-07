using rental_cars_application.core.services;
using rental_cars_application.modules.home.presentation;
using rental_cars_application.modules.home.presentation.forms.customer;
using rental_cars_application.modules.home.presentation.forms.employee;
using rental_cars_application.modules.settings.presentation.forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rental_cars_application
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SignInForm());  
        }
    }
}
