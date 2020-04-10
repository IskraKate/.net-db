using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace _01_Disconnected_layer_proj._01_Model
{
    class Model : IModel
    {
        private static IModel _model = new Model();
        private SqlConnection _sqlConnection;
        private DataSet _myUsersDataSet;
        private SqlDataAdapter _sqlDataAdapter;
        private string _connectionString = "Data Source=(local);Initial Catalog=UsersDb;Integrated Security=True";

        private Model()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _myUsersDataSet = new DataSet("UsersDb");


            _sqlDataAdapter = new SqlDataAdapter();

            SelectCommand();
            InsertCommand();
            UpdateCommand();
            DeleteCommand();
        }

        static public IModel GetModel()
        {
            return _model;
        }

        public void Edit(User user)
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
            _sqlDataAdapter.Update(_myUsersDataSet);
        }

        public void Delete(User user)
        {
            for (int i = 0; i < _myUsersDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow selectedRow = _myUsersDataSet.Tables[0].Rows[i];

                if (selectedRow.Field<long>("Id") == user.Id)
                {
                    _myUsersDataSet.Tables[0].Rows[i].Delete();
                    break;
                }
            }

            _sqlDataAdapter.Update(_myUsersDataSet);
        }

        public void Add(User user)
        {
            DataTable dt = _myUsersDataSet.Tables[0];
            DataRow newRow = dt.NewRow();

            newRow.SetField<string>("Login", user.Login);
            newRow.SetField<string>("Password", user.Password);
            newRow.SetField<string>("Address", user.Address);
            newRow.SetField<long>("TelephoneNumber", user.TelephoneNumber);
            newRow.SetField<bool>("Admin", user.IsAdmin);

            dt.Rows.Add(newRow);

            _sqlDataAdapter.Update(_myUsersDataSet);
        }

        public List<User> Fill(List<User> userList)
        {
            if (userList.Count > 0)
                userList.Clear();

            _myUsersDataSet.Clear();
            _sqlDataAdapter.Fill(_myUsersDataSet);

            userList = _myUsersDataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new User
            {
                Id = dataRow.Field<long>("Id"),
                Login = dataRow.Field<string>("Login"),
                Password = dataRow.Field<string>("Password"),
                Address = dataRow.Field<string>("Address"),
                TelephoneNumber = dataRow.Field<long>("TelephoneNumber"),
                IsAdmin = dataRow.Field<bool>("Admin")

            }).ToList();

            return userList;
        }

        public void SelectCommand()
        {
            _sqlDataAdapter.SelectCommand = new SqlCommand("SELECT Id, Login, Password, Address, TelephoneNumber, Admin FROM Users",
                                                            _sqlConnection);
        }

        public void InsertCommand()
        {
            _sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Users(Login, Password, Address, TelephoneNumber, Admin)" +
                                               "VALUES (@Login, @Password, @Address, @TelephoneNumber, @Admin)", _sqlConnection);
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "Login");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 50, "Address");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@TelephoneNumber", SqlDbType.BigInt, 8, "TelephoneNumber");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Admin", SqlDbType.Bit, 1, "Admin");
        }

        public void UpdateCommand()
        {
            _sqlDataAdapter.UpdateCommand = new SqlCommand("UPDATE Users " +
                                                           "SET Login = @Login, Password = @Password, Address = @Address, TelephoneNumber = @TelephoneNumber, Admin = @Admin " +
                                                           "WHERE Id = @Id", _sqlConnection);
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Login", SqlDbType.NVarChar, 50, "Login");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Password", SqlDbType.NVarChar, 50, "Password");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 50, "Address");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@TelephoneNumber", SqlDbType.BigInt, 8, "TelephoneNumber");
            _sqlDataAdapter.UpdateCommand.Parameters.Add("@Admin", SqlDbType.Bit, 1, "Admin");
        }

        public void DeleteCommand()
        {
            _sqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Users Where Id = @Id", _sqlConnection);
            _sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");
        }
    }
}
