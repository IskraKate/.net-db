using System;
using System.Windows.Forms;
using Sales.PresenterNamespace;

namespace Sales
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
            var mainForm = new MainForm();
            var presenter = new Presenter(mainForm);
            Application.Run(mainForm);
        }
    }
}
