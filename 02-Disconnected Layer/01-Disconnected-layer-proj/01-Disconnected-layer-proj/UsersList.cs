using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._03_Presenter;
using System;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    static class UsersList
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Users userListForm = new Users();
            Model model = new Model();
            UserListFormPresenter userListFormPresenter = new UserListFormPresenter(userListForm, model);
            Application.Run(userListForm);
        }
    }
}
