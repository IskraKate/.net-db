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
        private delegate void UserAllInfoHadler(User user);
        private event UserAllInfoHadler UserAllInfoEvent;

        public Users()
        {
            InitializeComponent();

            string connectionString = "Data Source=(local);Initial Catalog=UsersDb;Integrated Security=True";
            _sqlConnection = new SqlConnection(connectionString);

            _myUsersDataSet = new DataSet("UsersDb");

            FillListBox();
        }

        private void FillListBox()
        {
            _myUsersDataSet.Clear();

            var sqlDataAdapter = new SqlDataAdapter(
                "SELECT Id, Login, Password, Address, TelephoneNumber, Admin FROM Users",
                _sqlConnection);
            sqlDataAdapter.Fill(_myUsersDataSet);
           
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
                listBoxUsers.Items.Add(user.Login);
            }
        }

        private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxUsers.SelectedItems.Count > 0)
            {
                int index;
                var fullUserInfoForm = new FullUserInfoForm(this);
                UserAllInfoEvent += fullUserInfoForm.UserFullInfoShow;
                index = listBoxUsers.Items.IndexOf(listBoxUsers.SelectedItems[0]);
                UserAllInfoEvent(_userList[index]);
                fullUserInfoForm.ShowDialog();
            }
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm();
            addForm.Show();
        }
    }
}
