using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _03_Disconnected_layer_proj
{
    public partial class FridgeShop : Form
    {
        private List<Check> _checkList = new List<Check>();

        public SqlConnection SqlConnection { get; private set; }
        public DataSet MyFridgeDataSet { get; private set; }
        public SqlDataAdapter SqlDataAdapter { get; private set; }

        public FridgeShop()
        {
            InitializeComponent();

            string connectionString = "Data Source=(local);Initial Catalog=FridgeShopDB;Integrated Security=True";
            SqlConnection = new SqlConnection(connectionString);
            MyFridgeDataSet = new DataSet("FridgeShopDB");


            SqlDataAdapter = new SqlDataAdapter();

            
            SqlDataAdapter.DeleteCommand = new SqlCommand("DELETE FROM Checks Where Id = @Id", SqlConnection);
            SqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");

            FillDataGridView();
        }

        private void FillDataGridView()
        {
            MyFridgeDataSet = new DataSet("FridgeShopDB");
            SqlDataAdapter.SelectCommand = new SqlCommand("SELECT Checks.Id, Checks.Number, Date, Buyers.Name [Buyer], Sellers.Name [Seller], Fridges.Brand " +
                                                "FROM Checks, Buyers, Sellers, Fridges " +
                                                "WHERE Checks.BuyerFk = Buyers.Id AND Checks.SellerFk = Sellers.Id AND Checks.FridgeFk = Fridges.Id",
                                                SqlConnection);


            MyFridgeDataSet.Clear();
            SqlDataAdapter.Fill(MyFridgeDataSet);

            _checkList = MyFridgeDataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Check(dataRow.Field<long>("Id"), 
                      dataRow.Field<int>("Number"),
                      dataRow.Field<DateTime>("Date"),
                      dataRow.Field<string>("Buyer"),
                      dataRow.Field<string>("Seller"),
                      dataRow.Field<string>("Brand")
            )).ToList();

            dataGridView.DataSource = MyFridgeDataSet.Tables[0];
        }


        private void AddRecieptButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.ShowDialog();
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                _checkList.Remove(_checkList.Where(c => c.Id == int.Parse(row.Cells[0].Value.ToString())).Single());
                dataGridView.Rows.Remove(row);
            }

            SqlDataAdapter.Update(MyFridgeDataSet);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML Files |*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XDocument xdoc = new XDocument();
                    XElement checks = new XElement("checks");

                    foreach (Check check in _checkList)
                    {
                        XElement checkEl = new XElement("check");

                        XElement id = new XElement("id", check.Id);
                        XElement number = new XElement("Number", check.Number);
                        XElement date = new XElement("Date", check.Date);

                        XElement buyer = new XElement("Buyer");
                        XElement buyerName = new XElement("Name", check.Buyer);
                        buyer.Add(buyerName);

                        XElement seller = new XElement("Seller");
                        XElement sellerName = new XElement("Name", check.Seller);
                        seller.Add(sellerName);

                        XElement fridge = new XElement("Fridge");
                        XElement brand = new XElement("Brand", check.Fridge);
                        fridge.Add(brand);

                        checkEl.Add(id, number, date, buyer, seller, fridge);
                        checks.Add(checkEl);
                    }


                    xdoc.Add(checks);
                    xdoc.Save(saveFileDialog.FileName + ".xml");
                }
            }
        }


        public void AddCheck(Check check)
        {
            MyFridgeDataSet = new DataSet("FridgeShopDB");

            SqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Checks(Number, Date, BuyerFk, SellerFk, FridgeFk)" +
                                            "VALUES (@Number, @Date, @BuyerFk, @SellerFk, @FridgeFk)", SqlConnection);
            SqlDataAdapter.InsertCommand.Parameters.Add("@Number", SqlDbType.BigInt, 8, "Number");
            SqlDataAdapter.InsertCommand.Parameters.Add("@Date", SqlDbType.Date, 3, "Date");
            SqlDataAdapter.InsertCommand.Parameters.Add("@BuyerFk", SqlDbType.BigInt, 8, "BuyerFk");
            SqlDataAdapter.InsertCommand.Parameters.Add("@SellerFk", SqlDbType.BigInt, 8, "SellerFk");
            SqlDataAdapter.InsertCommand.Parameters.Add("@FridgeFk", SqlDbType.BigInt, 8, "FridgeFk");


            SqlDataAdapter.SelectCommand = new SqlCommand("SELECT Number, Date, BuyerFk, SellerFk, FridgeFk " +
                                                          "FROM Checks", SqlConnection);
            SqlDataAdapter.Fill(MyFridgeDataSet);



            DataRow dataRow = MyFridgeDataSet.Tables[0].NewRow();

            dataRow.SetField<int>("Number", check.Number);
            dataRow.SetField<DateTime>("Date", check.Date);
            dataRow.SetField<long>("BuyerFk", check.BuyerId);
            dataRow.SetField<long>("SellerFk", check.SellerId);
            dataRow.SetField<long>("FridgeFk", check.FridgeId);

            MyFridgeDataSet.Tables[0].Rows.Add(dataRow);
            _checkList.Add(check);

            SqlDataAdapter.Update(MyFridgeDataSet);
            FillDataGridView();
        }

        private void FridgeShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection.Close();
        }
    }
}
