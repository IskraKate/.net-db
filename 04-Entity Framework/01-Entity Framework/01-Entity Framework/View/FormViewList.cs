using System;
using System.Windows.Forms;
using View;

namespace SalesNamespace
{
    public partial class MainForm : Form, IView
    {
        public event ViewHandler ViewEvent;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(listView);
        }
    }
}
