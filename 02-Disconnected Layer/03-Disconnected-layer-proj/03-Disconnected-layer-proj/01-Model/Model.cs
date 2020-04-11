using _03_Disconnected_layer_proj.Elements;
using _03_Disconnected_layer_proj.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private Model()
        {
            _connectionString = "Data Source=(local);Initial Catalog=FridgeShopDB;Integrated Security=True";

            _sqlConnection = new SqlConnection(_connectionString);
            _dataSet = new DataSet("FridgeShopDB");

            _sqlDataAdapter = new SqlDataAdapter();
        }

        public static IModel GetModel
        {
            get
            {
                return _model;
            }
        }

        List<Check> IModel.FillCkeckList(List<Check> checks)
        {
            _command = "SELECT Checks.Id, Checks.Number, Date, Buyers.Name [Buyer], BuyerFk, Sellers.Name [Seller], SellerFk, Fridges.Brand [Brand], FridgeFk " +
                       "FROM Checks, Buyers, Sellers, Fridges " +
                       "WHERE Checks.BuyerFk = Buyers.Id AND Checks.SellerFk = Sellers.Id AND Checks.FridgeFk = Fridges.Id";

            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);


            _dataSet.Clear();
            _sqlDataAdapter.Fill(_dataSet);

            checks = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Check
            {
                Id = dataRow.Field<long>("Id"),
                Number = dataRow.Field<int>("Number"),
                Date = dataRow.Field<DateTime>("Date"),

                Brand = dataRow.Field<string>("Brand"),
                BrandFk = dataRow.Field<long>("FridgeFk"),

                Buyer = dataRow.Field<string>("Buyer"),
                BuyerFk = dataRow.Field<long>("BuyerFk"),

                Seller = dataRow.Field<string>("Seller"),
                SellerFk = dataRow.Field<long>("SellerFk")
            }).ToList();

            return checks;
        }

        void IModel.Delete(Check check)
        {
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
                        XElement buyerName = new XElement("Name", check.Buyer);
                        buyer.Add(buyerName);

                        XElement seller = new XElement("Seller");
                        XElement sellerName = new XElement("Name", check.Seller);
                        seller.Add(sellerName);

                        XElement fridge = new XElement("Fridge");
                        XElement brand = new XElement("Brand", check.Brand);
                        fridge.Add(brand);

                        checkEl.Add(id, number, date, buyer, seller, fridge);
                        checks.Add(checkEl);
                    }

                    xdoc.Add(checks);
                    xdoc.Save(saveFileDialog.FileName + ".xml");
                }
            }
        }

        public List<Buyer> FillBuyerList(List<Buyer> buyers)
        {
            _command = "SELECT Id, Name FROM Buyers";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);

            _sqlDataAdapter.Fill(_dataSet);

            buyers = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Buyer
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            return buyers;
        }

        public List<Fridge> FillFridgeList(List<Fridge> fridges)
        {
            _command = "SELECT Id, Brand, Number FROM Fridges";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);

            _sqlDataAdapter.Fill(_dataSet);

            fridges = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Fridge
            {
                Id = dataRow.Field<long>("Id"),
                Brand = dataRow.Field<string>("Name"),
                Number = dataRow.Field<string>("Number").ToString()
            }).ToList();

            return fridges;
        }

        public List<Seller> FillSellerList(List<Seller> sellers)
        {
            _command = "SELECT Id, Name FROM Sellers";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_command, _sqlConnection);

            _sqlDataAdapter.Fill(_dataSet);

            sellers = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Seller
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            return sellers;
        }
    }
}
