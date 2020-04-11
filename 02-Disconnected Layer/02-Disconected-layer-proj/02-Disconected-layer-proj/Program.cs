using _02_Disconected_layer_proj._01_Model;
using _02_Disconected_layer_proj._03_Presenter;
using System;
using System.Windows.Forms;

namespace _02_Disconected_layer_proj
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
            MainForm booksAuthorsPresses = new MainForm();
            MainFormPresenter mainFormPresenter = new MainFormPresenter(booksAuthorsPresses, Model.GetModel);
            Application.Run(booksAuthorsPresses);
        }
    }
}
