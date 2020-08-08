using ModelNamespace;
using PresenterNamespace;
using System;
using System.Windows.Forms;

namespace SalesNamespace
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
                SalesContext salesContext = new SalesContext();
                var mainForm = new MainForm();
                var presenter = new Presenter(mainForm, salesContext);
                Application.Run(mainForm);
        }
    }
}
