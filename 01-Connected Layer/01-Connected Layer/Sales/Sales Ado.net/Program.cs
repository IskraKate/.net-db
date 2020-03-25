using System;
using System.Windows.Forms;
using Sales.PresenterNamespace;

namespace Sales
{
    static class Program
    {
        private static Presenter presenter;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            presenter = new Presenter();
            Application.Run(presenter.MyMainForm);
        }
    }
}
