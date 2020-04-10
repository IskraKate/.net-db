using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using System;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class UserListFormPresenter
    {
       private IView _view;
       private IModel _model;

        public UserListFormPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ViewEvent += FillListFromBase;
        }

        public void FillListFromBase(object sender, EventArgs e)
        {
            _view.UserList = _model.Fill(_view.UserList);
        }
    }
}
