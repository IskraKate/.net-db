using System;
using System.Windows.Forms;

namespace Sales
{
    public partial class MainForm : Form
    {
        public bool IsClosed { get; set; }

        public ListView ListView
        {
            get
            {
                return listView;
            }
            set
            {
                listView = value;
            }
        }

        public MainForm(ListView listView)
        {
            InitializeComponent();
            this.listView = listView;
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
            IsClosed = true;
        }
    }
}
