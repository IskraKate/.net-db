using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class Presenter
    {
        private List<User> _userList = new List<User>();
        private IModel _model;
        private IView _view;

        public Presenter(IModel model, IView view)
        {
            _model = model;
            _view = view;
            FillListBox();
            _view.GetUserEvent += GetUser;
            _view.CheckChangedEvent += CheckChanged;
            _view.AddUserEvent += AddUser;
            _view.EditUserEvent += EditUser;
            _view.DeleteUserEvent += DeleteUser;
            _view.FormClosed += _view_FormClosed;
            _view.CheckUniqueEvent += _view_CheckUniqueEvent;
        }

        private bool _view_CheckUniqueEvent(string login)
        {
            foreach (var item in _userList)
            {
                if (item.Login == login)
                {
                    return false;
                }
            }

            return true;
        }

        private void _view_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        { 
            _model.SqlDataAdapter.Update(_model.MyUsersDataSet);
        }

        public void FillListBox()
        {
            _model.MyUsersDataSet.Clear();
            _model.SqlDataAdapter.Fill(_model.MyUsersDataSet);

            _view.ListBoxUser.Items.Clear();
            _userList.Clear();

            _userList = _model.MyUsersDataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new User
            {
                Id = dataRow.Field<long>("Id"),
                Login = dataRow.Field<string>("Login"),
                Password = dataRow.Field<string>("Password"),
                Address = dataRow.Field<string>("Address"),
                TelephoneNumber = dataRow.Field<long>("TelephoneNumber"),
                IsAdmin = dataRow.Field<bool>("Admin")
            }).ToList();

            foreach (var user in _userList)
            {
                if (user.IsAdmin && !_view.CheckBoxAdmin.Checked)
                {
                    continue;
                }

                _view.ListBoxUser.Items.Add(user.Login);
            }
        }     

        public void AddUser(User user)
        {
            DataTable dt = _model.MyUsersDataSet.Tables[0];
            DataRow newRow = dt.NewRow();

            newRow.SetField<string>("Login", user.Login);
            newRow.SetField<string>("Password", user.Password);
            newRow.SetField<string>("Address", user.Address);
            newRow.SetField<long>("TelephoneNumber", user.TelephoneNumber);
            newRow.SetField<bool>("Admin", user.IsAdmin);

            dt.Rows.Add(newRow);

            _userList.Add(user);

            _model.SqlDataAdapter.Update(_model.MyUsersDataSet);
            FillListBox();
            _view.ListBoxUser.Update();
        }

        public void EditUser(User user)
        {
            foreach (DataRow selectedRow in _model.MyUsersDataSet.Tables[0].Rows)
            {
                if (selectedRow.Field<long>("Id") == user.Id)
                {
                    selectedRow.SetField<string>("Login", user.Login);
                    selectedRow.SetField<string>("Password", user.Password);
                    selectedRow.SetField<string>("Address", user.Address);
                    selectedRow.SetField<long>("TelephoneNumber", user.TelephoneNumber);
                    selectedRow.SetField<bool>("Admin", user.IsAdmin);
                }
            }

            for (int i = 0; i < _userList.Count; i++)
            {
                if (_userList[i].Id == user.Id)
                {
                    _userList[i] = new User
                    {
                        Id = user.Id,
                        Login = user.Login,
                        Password = user.Password,
                        Address = user.Address,
                        TelephoneNumber = user.TelephoneNumber,
                        IsAdmin = user.IsAdmin
                    };
                }
            }

            _model.SqlDataAdapter.Update(_model.MyUsersDataSet);
            FillListBox();
        }

        public void DeleteUser(User user)
        {
            for (int i = 0; i < _model.MyUsersDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow selectedRow = _model.MyUsersDataSet.Tables[0].Rows[i];

                if (selectedRow.Field<long>("Id") == user.Id)
                {
                    _model.MyUsersDataSet.Tables[0].Rows[i].Delete();
                    break;
                }
            }
            _userList.Remove(user);

            _model.SqlDataAdapter.Update(_model.MyUsersDataSet);
            FillListBox();
            _view.ListBoxUser.Update();
        }

        public void CheckChanged()
        {
            FillListBox();
        }
            
        public User GetUser(int index)
        {
            return _userList[index];
        }
    }
}
