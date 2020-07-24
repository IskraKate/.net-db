using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using _03_Disconnected_layer_proj._03_Presenter;
using System;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj
{
    public partial class FridgeShop : Form, IView, IDelete, ISave
    {
        public event ViewHandler ViewEvent;
        public event DeleteHandler DeleteEvent;
        public event SaveHandler SaveEvent;

        public FridgeShop()
        {
            InitializeComponent();
        }

        private void FillListView()
        {
            listViewCheck.Items.Clear();
            ViewEvent?.Invoke(listViewCheck);
        }

        private void AddRecieptButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            AddFormPresenter presenter = new AddFormPresenter(addForm);
            addForm.Load();

            addForm.ShowDialog();

            FillListView();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DeleteEvent(listViewCheck.SelectedIndices[0]);
            listViewCheck.Items.RemoveAt(listViewCheck.SelectedIndices[0]);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveEvent?.Invoke();
        }

        private void FridgeShop_Load(object sender, EventArgs e)
        {
            FillListView();
        }
    }
}
