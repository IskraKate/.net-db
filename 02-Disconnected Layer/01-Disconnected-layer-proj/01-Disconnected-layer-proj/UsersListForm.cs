using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public struct User
    {
        public long Id;
        public string Login;
        public string Password;
        public string Address;
        public long TelephoneNumber;
        public bool IsAdmin;
    }

    public partial class Users : Form
    {
        private SqlConnection _sqlConnection;
        private DataSet _myUsersDataSet;
        List<User> _userList = new List<User>();
        private SqlDataAdapter _sqlDataAdapter;

        public Users()
        {
            InitializeComponent();

            string connectionString = "Data Source=(local);Initial Catalog=UsersDb;Integrated Security=True";
            _sqlConnection = new SqlConnection(connectionString);
            _myUsersDataSet = new DataSet("UsersDb");


            _sqlDataAdapter = new SqlDataAdapter();

            _sqlDataAdapter.SelectCommand = new SqlCommand("SELECT Id, Login, Password, Address, TelephoneNumber, Admin FROM Users",
                                                            _sqlConnection); ;

            _sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Users(Login, Password, Address, TelephoneNumber, Admin)" +
                                                           "VALUES (@Login, @Password, @Address, @TelephoneNumber, @Admin)", _sqlConnection);
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "Login");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 50, "Address");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@TelephoneNumber", SqlDbType.BigInt, 8, "TelephoneNumber");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Admin", SqlDbType.Bit, 1, "Admin");

            _sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE Users " +
                                                           "SET Login = @Login, Password = @Password, Address = @Address, TelephoneNumber = @TelephoneNumber, Admin = @Admin " +
                                                           "WHERE Id = @Id", _sqlConnection);
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "Login");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 50, "Address");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@TelephoneNumber", SqlDbType.BigInt, 8, "TelephoneNumber");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Admin", SqlDbType.Bit, 1, "Admin");

            _sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Users Where Id = @Id", _sqlConnection);
            _sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");

            FillListBox();
        }

        public bool CheckUnique(string login)
        {
            foreach(User usr in _userList)
            {
                if(usr.Login == login)
                {
                    return false;
                }
            }

            return true;
        }

        public void AddUser(User user)
        {
            DataTable dt = _myUsersDataSet.Tables[0];
            DataRow newRow = dt.NewRow();

            newRow.SetField<string>("Login", user.Login);
            newRow.SetField<string>("Password", user.Password);
            newRow.SetField<string>("Address", user.Address);
            newRow.SetField<long>("TelephoneNumber", user.TelephoneNumber);
            newRow.SetField<bool>("Admin", user.IsAdmin);

            dt.Rows.Add(newRow);

            _userList.Add(user);

            _sqlDataAdapter.Update(_myUsersDataSet);
            FillListBox();
        }

        public void EditUser(User user)
        {
            foreach (DataRow selectedRow in _myUsersDataSet.Tables[0].Rows)
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

            _sqlDataAdapter.Update(_myUsersDataSet);
            FillListBox();
        }

        public void DeleteUser(User user)
        {
            for(int i = 0; i < _myUsersDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow selectedRow = _myUsersDataSet.Tables[0].Rows[i];

                if (selectedRow.Field<long>("Id") == user.Id)
                {
                    _myUsersDataSet.Tables[0].Rows[i].Delete();
                    break;
                }
            }
            _userList.Remove(user);

            _sqlDataAdapter.Update(_myUsersDataSet);
            FillListBox();
        }

        private void FillListBox()
        {
            _myUsersDataSet.Clear();
            _sqlDataAdapter.Fill(_myUsersDataSet);

            listBoxUsers.Items.Clear();
            _userList.Clear();

            _userList = _myUsersDataSet.Tables[0].AsEnumerable().Select(dataRow =>
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
                if(user.IsAdmin && !checkBoxAdminShower.Checked)
                {
                    continue;
                }

                listBoxUsers.Items.Add(user.Login);                
            }
        }

        private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxUsers.SelectedItems.Count > 0)
            {
                var fullUserInfoForm = new FullUserInfoForm(this, _userList[listBoxUsers.SelectedIndex]);
                fullUserInfoForm.ShowDialog();
            }
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm(this);
            addForm.Show();
        }

        private void checkBoxAdminShower_CheckedChanged(object sender, System.EventArgs e)
        {
            FillListBox();
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
            _sqlDataAdapter.Update(_myUsersDataSet);
        }
    }
}
