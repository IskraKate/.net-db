using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj
{
    public partial class FridgeShop : Form, IView, IDelete, ISave
    {
        public List<Check> CheckList { get; set; }
        public Check check { get; set; }

        public event EventHandler ViewEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;

        public FridgeShop()
        {
            InitializeComponent();

            CheckList = new List<Check>();
        }


        private void FillListView()
        {
            foreach (var check in CheckList)
            {
                ListViewItem item = listViewCheck.Items.Add(new ListViewItem());
                item.Text = check.Number.ToString();
                item.SubItems.Add(check.Date.ToString());
                item.SubItems.Add(check.Brand);
                item.SubItems.Add(check.Buyer);
                item.SubItems.Add(check.Seller);
            }

        }

        private void AddRecieptButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(this);
            addForm.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            check = CheckList[listViewCheck.SelectedIndices[0]];
            DeleteEvent(this, EventArgs.Empty);
            listViewCheck.Items.RemoveAt(listViewCheck.SelectedIndices[0]);
            CheckList.Remove(check);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveEvent?.Invoke(this, EventArgs.Empty);
        }

        private void FridgeShop_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillListView();
        }

        private void AddCheck(Check check)
        {
            //    MyFridgeDataSet = new DataSet("FridgeShopDB");

            //    SqlDataAdapter.InsertCommand = new SqlCommand("INSERT INTO Checks(Number, Date, BuyerFk, SellerFk, FridgeFk)" +
            //                                    "VALUES (@Number, @Date, @BuyerFk, @SellerFk, @FridgeFk)", SqlConnection);
            //    SqlDataAdapter.InsertCommand.Parameters.Add("@Number", SqlDbType.BigInt, 8, "Number");
            //    SqlDataAdapter.InsertCommand.Parameters.Add("@Date", SqlDbType.Date, 3, "Date");
            //    SqlDataAdapter.InsertCommand.Parameters.Add("@BuyerFk", SqlDbType.BigInt, 8, "BuyerFk");
            //    SqlDataAdapter.InsertCommand.Parameters.Add("@SellerFk", SqlDbType.BigInt, 8, "SellerFk");
            //    SqlDataAdapter.InsertCommand.Parameters.Add("@FridgeFk", SqlDbType.BigInt, 8, "FridgeFk");


            //    SqlDataAdapter.SelectCommand = new SqlCommand("SELECT Number, Date, BuyerFk, SellerFk, FridgeFk " +
            //                                                  "FROM Checks", SqlConnection);
            //    SqlDataAdapter.Fill(MyFridgeDataSet);



            //    DataRow dataRow = MyFridgeDataSet.Tables[0].NewRow();

            //    dataRow.SetField<int>("Number", check.Number);
            //    dataRow.SetField<DateTime>("Date", check.Date);
            //    dataRow.SetField<long>("BuyerFk", check.BuyerId);
            //    dataRow.SetField<long>("SellerFk", check.SellerId);
            //    dataRow.SetField<long>("FridgeFk", check.FridgeId);

            //    MyFridgeDataSet.Tables[0].Rows.Add(dataRow);
            //    CheckList.Add(check);

            //    SqlDataAdapter.Update(MyFridgeDataSet);
            //    FillDataGridView();
            //}

            //private void FridgeShop_FormClosing(object sender, FormClosingEventArgs e)
            //{
            //    SqlConnection.Close();
            //}
        }
    }
}
