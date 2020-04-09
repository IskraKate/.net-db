using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.PresenterNamespace;
using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment
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
            var model = new Model();
            var formNameList = new FormNameList();
            var presenter = new Presenter(formNameList, model);
            Application.Run(formNameList);
        }
    }
}
