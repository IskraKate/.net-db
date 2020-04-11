using _03_Disconnected_layer_proj._03_Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var fridgeShop = new FridgeShop();
            MainFormPresenter mainFormPresenter = new MainFormPresenter(fridgeShop, _03_Disconnected_layer_proj._01_Model.Model.GetModel);
            Application.Run(fridgeShop);
        }
    }
}
