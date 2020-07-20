using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using System;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class UserListFormPresenter
    {
        private IView _view;

        public UserListFormPresenter(IView view)
        {
            _view = view;
            _view.ViewEvent += FillList;
        }

        public void FillList(object sender, EventArgs e)
        {
            Model.GetModel().Fill();

            foreach (var user in Model.GetModel().Users)
            {
                if (_view.IsChecked)
                    _view.ListBox.Items.Add(user.Login);
                else
                {
                    if (_view.IsAdmin)
                        continue;
                    else
                        _view.ListBox.Items.Add(user.Login);
                }
            }
        }
    }
}
