using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using _03_Disconnected_layer_proj._03_Presenter;
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
            listViewCheck.Items.Clear();

            foreach (var check in CheckList)
            {
                ListViewItem item = listViewCheck.Items.Add(new ListViewItem());
                item.Text = check.Number.ToString();
                item.SubItems.Add(check.Date.ToShortDateString());
                item.SubItems.Add(check.Fridge.Brand);
                item.SubItems.Add(check.Buyer.Name);
                item.SubItems.Add(check.Seller.Name);
            }

        }

        private void AddRecieptButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(CheckList);
            AddFormPresenter presenter = new AddFormPresenter(addForm, _01_Model.Model.GetModel);
            addForm.Load();

            addForm.ShowDialog();

            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillListView();
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
    }
}
