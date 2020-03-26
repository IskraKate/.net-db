using Sales.View;
using System;
using System.Windows.Forms;

namespace Sales
{
    public partial class MainForm : Form, IView
    {
        public bool IsClosed { get; set; }
        public System.Windows.Forms.Form Form { get; set; }
        ListView IView.GetListView { get => listView; }
        ListViewItem listViewItem;

        public ListViewItem GetListViewItem
        {
            get
            {
                return listViewItem;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            IsClosed = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Connection with Db was closed");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        public void NewListViewItem()
        {
            listViewItem = listView.Items.Add(new ListViewItem());
        }
    }
}
