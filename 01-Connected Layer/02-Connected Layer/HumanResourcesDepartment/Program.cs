using HumanResourcesDepartment._03_Presenter;
using HumanResourcesDepartment.ModelNamespace;
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
                var formNameList = new FormNameList();
                var nameListPresenter = new NameListPresenter(formNameList, Model.GetModel());
                Application.Run(formNameList);
        }
    }
}
