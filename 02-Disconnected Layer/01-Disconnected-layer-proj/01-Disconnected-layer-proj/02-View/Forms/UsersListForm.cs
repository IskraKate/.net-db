using _01_Disconnected_layer_proj._02_View;
using _01_Disconnected_layer_proj._03_Presenter;
using System;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class Users : Form, IView
    {
        public string Login { get; set; }
        public bool IsChecked { get; set; }
        public ListBox ListBox { get; set; }
        public bool IsAdmin { get; set; }

        public event EventHandler ViewEvent;

        public Users()
        {
            InitializeComponent();
            ListBox = listBoxUsers;
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm();
            var AddFormPresenter = new AddFormPresenter(addForm);
            addForm.ShowDialog();

            FillListBox();
        }

        public void FillListBox()
        {
            if(listBoxUsers.Items.Count>0)
                listBoxUsers.Items.Clear();

            ViewEvent?.Invoke(this, EventArgs.Empty);
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Users_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillListBox();
        }

        private void listBoxUsers_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listBoxUsers.SelectedItems.Count > 0)
            {
                var fullUserInfoForm = new FullUserInfoForm(listBoxUsers.SelectedIndex);
                var fullUserListPresenter = new FullUserListPresenter(fullUserInfoForm);
                fullUserInfoForm.ShowDialog();
                ViewEvent?.Invoke(this, EventArgs.Empty);
                FillListBox();
            }
        }

        private void checkBoxAdminShower_CheckedChanged(object sender, EventArgs e)
        {
            FillListBox();
        }
    }
}
