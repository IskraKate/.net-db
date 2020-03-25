using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sales.Model
{
    class ConnectionWithDb
    {
        private SqlConnection _connection = new SqlConnection();
        private SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
        private string _sqlString;
        private ListView _listView = new ListView();
        public bool IsConnected { get; set; }

        public ConnectionWithDb()
        {
            _sqlString =
                            "SELECT Buyers.FirstName AS BFirstName, Buyers.LastName AS BLastName, Salers.FirstName AS SFirstName, Salers.LastName AS SLastName, Sales.MoneySum, Sales.[Date] " +
                            "FROM Salers, Buyers, Sales " +
                            "WHERE Sales.BuyerFk = Buyers.Id AND Sales.SalerFk = Salers.Id";
            Initialize();
        }

        public void Initialize()
        {
            _builder.DataSource = "(local)";
            _builder.InitialCatalog = "Sales";
            _builder.IntegratedSecurity = true;

            _connection.ConnectionString = _builder.ConnectionString;
        }

        public void OpenConnection()
        {
            try
            {
                _connection.Open();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                IsConnected = false;
            }
        }

        public ListView FillListWithElements()
        {
            try
            {
                using (SqlCommand command = new SqlCommand(_sqlString, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = _listView.Items.Add(new ListViewItem());
                        item.Text = (string)reader["BFirstname"];
                        item.SubItems.Add((string)reader["BLastname"]);
                        item.SubItems.Add((string)reader["SFirstname"]);
                        item.SubItems.Add((string)reader["SLastname"]);
                        item.SubItems.Add(((int)reader["MoneySum"]).ToString());
                        item.SubItems.Add(((DateTime)reader["Date"]).ToShortDateString());
                    }
                }
                return _listView;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return _listView;
            }
        }

        public void CloseConnection()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
                IsConnected = false;
            }
        }
    }
}
