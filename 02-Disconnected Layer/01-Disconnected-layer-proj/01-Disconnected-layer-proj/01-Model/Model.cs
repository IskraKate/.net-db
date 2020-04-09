using System.Data;
using System.Data.SqlClient;

namespace _01_Disconnected_layer_proj._01_Model
{
    class Model : IModel
    {
        private SqlConnection _sqlConnection;
        private DataSet _myUsersDataSet;
        private SqlDataAdapter _sqlDataAdapter;
        private string _connectionString = "Data Source=(local);Initial Catalog=UsersDb;Integrated Security=True";

        public Model()
        {
            _sqlConnection = new SqlConnection(_connectionString);
            _myUsersDataSet = new DataSet("UsersDb");


            _sqlDataAdapter = new SqlDataAdapter();

            SelectCommand();
            InsertCommand();
            UpdateCommand();
            DeleteCommand();
        }

        public DataSet MyUsersDataSet
        {
            get { return _myUsersDataSet; }
        }

        public SqlDataAdapter SqlDataAdapter
        {
            get { return _sqlDataAdapter; }
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
