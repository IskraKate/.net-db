using Sales.View;
using System;
using System.Windows.Forms;

namespace Sales
{
    public partial class MainForm : Form, IView
    {
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
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Connection with Db was closed");
        }

        public void NewListViewItem()
        {
            listViewItem = listView.Items.Add(new ListViewItem());
        }
    }
}
