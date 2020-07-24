using _03_Disconnected_layer_proj._01_Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace _03_Disconnected_layer_proj._01_Model
{
    class Model : IModel
    {
        private static IModel _model = new Model();

        private SqlConnection _sqlConnection;
        private DataSet _dataSet;
        private SqlDataAdapter _sqlDataAdapter;
        private string _connectionString;
        private string _command;

        public List<Buyer> Buyers { get; set; }
        public List<Seller> Sellers { get; set; }
        public List<Fridge> Fridges { get; set; }
        public List<Check> Checks { get; set; }

        private Model()
        {
            _connectionString = "Data Source=(local);Initial Catalog=FridgeShopDB;Integrated Security=True";

            _sqlConnection = new SqlConnection(_connectionString);
            _dataSet = new DataSet("FridgeShopDB");

            _sqlDataAdapter = new SqlDataAdapter();

            Buyers = new List<Buyer>();
            Sellers = new List<Seller>();
            Fridges = new List<Fridge>();

            Buyers = FillBuyerList();
            Sellers = FillSellerList();
            Fridges = FillFridgeList();
        }

        public static IModel GetModel
        {
            get
            {
                return _model;
            }
        }

        private void FillMainData()
        {
            _command = "SELECT Checks.Id, Checks.Number, Date, BuyerFk, SellerFk, FridgeFk " +
           "FROM Checks, Buyers, Sellers, Fridges " +
           "WHERE Checks.BuyerFk = Buyers.Id AND Checks.SellerFk = Sellers.Id AND Checks.FridgeFk = Fridges.Id";

            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);


            _dataSet.Clear();
            _sqlDataAdapter.Fill(_dataSet);
        }

        public void Fill()
        {
            FillMainData();

            Checks = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Check
            {
                Id = dataRow.Field<long>("Id"),
                Number = dataRow.Field<string>("Number"),
                Date = dataRow.Field<DateTime>("Date"),

                Buyer = Buyers.Where(b => b.Id == dataRow.Field<long>("BuyerFk")).Single(),
                Seller = Sellers.Where(s => s.Id == dataRow.Field<long>("SellerFk")).Single(),
                Fridge = Fridges.Where(f => f.Id == dataRow.Field<long>("FridgeFk")).Single()
            }).ToList();


            _dataSet.Clear();
        }

        public void AddCheck(Check check)
        {
            _sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Checks(Number, Date, BuyerFk, SellerFk, FridgeFk)" +
                                                          "VALUES (@Number, @Date, @BuyerFk, @SellerFk, @FridgeFk)", _sqlConnection);
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Number", SqlDbType.NVarChar, 50, "Number");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@Date", SqlDbType.Date, 3, "Date");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@BuyerFk", SqlDbType.BigInt, 8, "BuyerFk");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@SellerFk", SqlDbType.BigInt, 8, "SellerFk");
            _sqlDataAdapter.InsertCommand.Parameters.Add("@FridgeFk", SqlDbType.BigInt, 8, "FridgeFk");

            DataRow dataRow = _dataSet.Tables[0].NewRow();
            dataRow.SetField("Number", check.Number);
            dataRow.SetField("Date", check.Date);
            dataRow.SetField("BuyerFk", check.Buyer.Id);
            dataRow.SetField("SellerFk", check.Seller.Id);
            dataRow.SetField("FridgeFk", check.Fridge.Id);

            _dataSet.Tables[0].Rows.Add(dataRow);

            _sqlDataAdapter.Update(_dataSet);
        }

        void IModel.Delete(Check check)
        {
            FillMainData();

            _command = "DELETE FROM Checks Where Id = @Id";
            _sqlDataAdapter.DeleteCommand = new SqlCommand(_command, _sqlConnection);
            _sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.BigInt, 8, "Id");

            foreach (DataRow row in _dataSet.Tables[0].Rows)
            {
                if (row.Field<long>("Id") == check.Id)
                {
                    row.Delete();
                    break;
                }
            }

            _sqlDataAdapter.Update(_dataSet);
        }

        void IModel.SaveToXML(List<Check> checkList)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "XML Files |*.xml";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XDocument xdoc = new XDocument();
                    XElement checks = new XElement("checks");

                    foreach (Check check in checkList)
                    {
                        XElement checkEl = new XElement("check");

                        XElement id = new XElement("id", check.Id);
                        XElement number = new XElement("Number", check.Number);
                        XElement date = new XElement("Date", check.Date);

                        XElement buyer = new XElement("Buyer");
                        XElement buyerName = new XElement("Name", check.Buyer.Name);
                        buyer.Add(buyerName);

                        XElement seller = new XElement("Seller");
                        XElement sellerName = new XElement("Name", check.Seller.Name);
                        seller.Add(sellerName);

                        XElement fridge = new XElement("Fridge");
                        XElement brand = new XElement("Brand", check.Fridge.Brand);
                        XElement fridgeNumber = new XElement("Number", check.Fridge.Number);
                        fridge.Add(brand);
                        fridge.Add(fridgeNumber);

                        checkEl.Add(id, number, date, buyer, seller, fridge);
                        checks.Add(checkEl);
                    }

                    xdoc.Add(checks);
                    xdoc.Save(saveFileDialog.FileName + ".xml");
                }
            }
        }

        private List<Buyer> FillBuyerList()
        {
            Buyers.Clear();
            _dataSet.Clear();

            _command = "SELECT Id, Name FROM Buyers";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);

            _sqlDataAdapter.Fill(_dataSet);

            Buyers = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Buyer
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            _dataSet.Clear();

            return Buyers;
        }

        private List<Fridge> FillFridgeList()
        {
            Fridges.Clear();
            _dataSet.Clear();

            _command = "SELECT Id, Brand, Number FROM Fridges";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);

            _sqlDataAdapter.Fill(_dataSet);

            Fridges = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Fridge
            {
                Id = dataRow.Field<long>("Id"),
                Brand = dataRow.Field<string>("Brand"),
                Number = dataRow.Field<string>("Number").ToString()
            }).ToList();

            _dataSet.Clear();

            return Fridges;
        }

        private List<Seller> FillSellerList()
        {
            Sellers.Clear();
            _dataSet.Clear();

            _command = "SELECT Id, Name FROM Sellers";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);

            _sqlDataAdapter.Fill(_dataSet);

            Sellers = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Seller
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            _dataSet.Clear();

            return Sellers;
        }

        public void AddBuyer(Buyer buyer)
        {
            bool isChecked = true ;

            foreach (var b in Buyers)
            {
                if(b.Name == buyer.Name)
                {
                    isChecked = false;
                }
            }

            if(isChecked)
            {
                _sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Buyers(Name)" +
                                                                "VALUES (@Name)", _sqlConnection);
                _sqlDataAdapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");


                DataRow dataRow = _dataSet.Tables[0].NewRow();
                dataRow.SetField("Name", buyer.Name);
                _dataSet.Tables[0].Rows.Add(dataRow);


                _sqlDataAdapter.Update(_dataSet);

                FillBuyerList();
            }
        }
        public void AddSeller(Seller seller)
        {
            bool isChecked = true;

            foreach (var s in Sellers)
            {
                if (s.Name == seller.Name)
                {
                    isChecked = false;
                }
            }

            if (isChecked)
            {
                _sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Sellers(Name)" +
                                                            "VALUES (@Name)", _sqlConnection);
                _sqlDataAdapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");


                DataRow dataRow = _dataSet.Tables[0].NewRow();
                dataRow.SetField("Name", seller.Name);
                _dataSet.Tables[0].Rows.Add(dataRow);


                _sqlDataAdapter.Update(_dataSet);

                FillSellerList();
            }
        }
        public void AddFridge(Fridge fridge)
        {
            bool isChecked = true;

            foreach (var f in Fridges)
            {
                if (f.Brand == fridge.Brand)
                {
                    isChecked = false;
                }
            }

            if (isChecked)
            {
                _sqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Fridges(Brand, Number)" +
                                                                "VALUES (@Name, @Number)", _sqlConnection);
                _sqlDataAdapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
                _sqlDataAdapter.InsertCommand.Parameters.Add("@Number", SqlDbType.NVarChar, 50, "Number");

                DataRow dataRow = _dataSet.Tables[0].NewRow();
                dataRow.SetField("Name", fridge.Brand);
                dataRow.SetField("Number", fridge.Number);
                _dataSet.Tables[0].Rows.Add(dataRow);


                _sqlDataAdapter.Update(_dataSet);

                FillFridgeList();
            }
        }

    }
}
