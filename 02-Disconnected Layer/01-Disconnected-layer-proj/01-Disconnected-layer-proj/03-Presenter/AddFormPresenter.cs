using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View.Interfaces;
using System.Linq;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class AddFormPresenter
    {
        private IViewFullInfo _view;
        private IViewAdd _add;
        private IModel _model;

        public AddFormPresenter(IViewFullInfo view)
        {
            _view = view;
            _add = (IViewAdd)view;
            _model = Model.GetModel();

            _add.AddEvent += AddToBase;
         }

        public void AddToBase()
        {
            if (_view.Login != string.Empty && _view.Password != string.Empty && _view.Email != string.Empty && _view.Telephone != string.Empty)
            {
                _model.Users.Add(new User
                {
                    Login = _view.Login,
                    Password = _view.Password,
                    Address = _view.Email,
                    TelephoneNumber = long.Parse(_view.Telephone),
                    IsAdmin = _view.IsAdmin
                });
            }
            else
            {
                return;
            }

            if (Check())
            {
                _view.LoginChecked = true;
            }
            else
            {
                _view.LoginChecked = false;
                _model.Users.Remove(_model.Users.Last());
            }

            _model.Add(_model.Users.Last());
        }

        public bool Check()
        {
            for (int i = 0; i < _model.Users.Count - 1; i++)
            {
                if (!CheckUnique(_view.Login, _model.Users[i].Login))
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
    }
}
