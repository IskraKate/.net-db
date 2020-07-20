using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View.Interfaces;
using System;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class FullUserListPresenter
    {
        private int _i;

        private IViewFullInfo _view;
        private IDelete _delete;
        private IModel _model;

        public FullUserListPresenter(IViewFullInfo view)
        {
            _view = view;
            _delete = (IDelete)view;
            _model = Model.GetModel();

            _view.ViewEvent += View;
            _view.EditEvent += OnUpdate;
            _delete.DeleteEvent += DeleteInBase;
        }

        public void View(int i)
        {
            _view.Login = _model.Users[i].Login;
            _view.Password = _model.Users[i].Password;
            _view.IsAdmin = _model.Users[i].IsAdmin;
            _view.Telephone = _model.Users[i].TelephoneNumber.ToString();
            _view.Email = _model.Users[i].Address;

            _i = i;
        }

        public void OnUpdate()
        {
            if (Check())
            {
                _model.Users[_i].Login = _view.Login;
                _view.LoginChecked = true;
                _model.Users[_i].Password = _view.Password;
                _model.Users[_i].Address = _view.Email;
                _model.Users[_i].TelephoneNumber = int.Parse(_view.Telephone);
                _model.Edit(_model.Users[_i]);
            }
            else
            {
                _view.LoginChecked = false;
            }
        }

        public bool Check()
        {
            for (int i = 0; i < _model.Users.Count - 1; i++)
            {
                if (!CheckUnique(_view.Login, _model.Users[i].Login) && i != _i)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckUnique(string login, string newLogin)
        {
            if (newLogin == login)
                return false;
            else
                return true;
        }

        public void DeleteInBase(object sender, EventArgs e)
        {
            _model.Delete(_model.Users[_i]);
        }
    }
}
