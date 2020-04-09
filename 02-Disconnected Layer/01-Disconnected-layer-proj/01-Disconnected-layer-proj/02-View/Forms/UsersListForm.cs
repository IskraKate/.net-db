using _01_Disconnected_layer_proj._02_View;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class Users : Form, IView
    {
        public event GetUserHandler GetUserEvent;
        public event CheckChangedHandler CheckChangedEvent;
        public event AddUserHandler AddUserEvent;
        public event EditUserHandler EditUserEvent;
        public event DeleteUserHandler DeleteUserEvent;
        public event CheckUniqueHandler CheckUniqueEvent;

        public Users()
        {
            InitializeComponent();
        }

        public ListBox ListBoxUser
        {
            get { return listBoxUsers; }
        }

        public CheckBox CheckBoxAdmin
        {
            get { return checkBoxAdminShower; }
        }

        public bool CheckUnique(string login)
        {
            return CheckUniqueEvent(login);
        }

        public void AddUser(User user)
        {
            AddUserEvent(user);
        }

        public void EditUser(User user)
        {
            EditUserEvent(user);
        }

        public void DeleteUser(User user)
        {
            DeleteUserEvent(user);
        }

        private void listBoxUsers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBoxUsers.SelectedItems.Count > 0)
            {
                var fullUserInfoForm = new FullUserInfoForm(this, GetUserEvent(listBoxUsers.SelectedIndex));
                fullUserInfoForm.ShowDialog();
            }
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm(this);
            addForm.Show();
        }

        private void checkBoxAdminShower_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckChangedEvent();
        }

        private void Users_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}
