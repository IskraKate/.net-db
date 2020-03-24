using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sales
{
    public partial class MainForm : Form
    {
        public static SqlConnection connection = new SqlConnection();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(local)";
            builder.InitialCatalog = "Sales";
            builder.IntegratedSecurity = true;

            connection.ConnectionString = builder.ConnectionString;

            try
            {
                connection.Open();
                FillListView();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        private void FillListView()
        {
            try
            {
                string sqlString =
                        "SELECT Buyers.FirstName As BFirstname, Buyers.LastName As BLastname, Salers.FirstName As SFirstname, Salers.LastName As SLastname, MoneySum, Date " +
                        "FROM Sales, Salers, Buyers " +
                        "WHERE Sales.SalerFk = Salers.Id AND Sales.BuyerFk = Buyers.Id";

                using (SqlCommand command = new SqlCommand(sqlString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListViewItem item = listView.Items.Add(new ListViewItem());
                        item.Text = (((string)reader["BFirstname"]));
                        item.SubItems.Add((string)reader["BLastname"]);
                        item.SubItems.Add((string)reader["SFirstname"]);
                        item.SubItems.Add((string)reader["SLastname"]);
                        item.SubItems.Add(((int)reader["MoneySum"]).ToString());
                        item.SubItems.Add(((DateTime)reader["Date"]).ToShortDateString());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Connection with Db was closed");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }
    }
}
