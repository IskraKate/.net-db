using Sales.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Sales
{
    public partial class MainForm : Form, IView
    {
        public List<Row> Rows { get; set; }

        public event EventHandler ViewEvent;

        public MainForm()
        {
            InitializeComponent();
        }

        public void FillListView()
        {
            foreach (var row in Rows)
            {
                ListViewItem listViewItem = listView.Items.Add(new ListViewItem());
                listViewItem.Text = row.BFirstName;
                listViewItem.SubItems.Add(row.BLastName);
                listViewItem.SubItems.Add(row.SFirstName);
                listViewItem.SubItems.Add(row.SLastName);
                listViewItem.SubItems.Add(row.MoneySum.ToString());
                listViewItem.SubItems.Add(row.Date.ToShortDateString());
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillListView();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ViewEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
