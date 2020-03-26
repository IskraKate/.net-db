using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sales.Model
{
    class ConnectionWithDb
    {
        private SqlConnection _connection = new SqlConnection();
        private SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
        private string _sqlString;
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

        public List<Row> FillListWithElements()
        {
            List<Row> rows = new List<Row>();
            try
            {
                using (SqlCommand command = new SqlCommand(_sqlString, _connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rows.Add(new Row
                        {
                            BFirstName = (string)reader["BFirstname"],
                            BLastName = ((string)reader["BLastname"]),
                            SFirstName = ((string)reader["SFirstname"]),
                            SLastName = ((string)reader["SLastname"]),
                            MoneySum = (((int)reader["MoneySum"]).ToString()),
                            Date  = (((DateTime)reader["Date"]).ToShortDateString())
                        });
                    }
                }
                return rows;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return rows;
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
