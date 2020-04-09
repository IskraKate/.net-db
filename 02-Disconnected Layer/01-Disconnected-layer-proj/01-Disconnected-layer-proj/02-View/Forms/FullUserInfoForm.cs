using System;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class FullUserInfoForm : Form
    {
        User _userInfo;

        public delegate void DeleleUserHandler(User user);
        public event DeleleUserHandler DeleteUser;

        public delegate void EditUserHandler(User user);
        public event EditUserHandler EditUser;

        public FullUserInfoForm()
        {
            InitializeComponent();
        }

        public FullUserInfoForm(Users usersList, User user)
        {
            InitializeComponent();

            //DeleteUser += usersList.DeleteUser;
            //EditUser += usersList.EditUser;

            _userInfo = user;
            textBoxLogin.Text = _userInfo.Login;
            textBoxPassword.Text = _userInfo.Password;
            textBoxAddress.Text = _userInfo.Address;
            checkBoxAdmin.Checked = _userInfo.IsAdmin;
            textBoxNumber.Text = _userInfo.TelephoneNumber.ToString();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonEdit.Enabled = false;
            buttonEditted.Enabled = true;
            textBoxLogin.ReadOnly = false;
            textBoxPassword.ReadOnly = false;
            textBoxAddress.ReadOnly = false;
            textBoxNumber.ReadOnly = false;
            checkBoxAdmin.Enabled = true;
        }

        private void buttonEditted_Click(object sender, EventArgs e)
        {
            _userInfo.Login = textBoxLogin.Text;
            _userInfo.Password = textBoxPassword.Text;
            _userInfo.Address = textBoxAddress.Text;
            _userInfo.TelephoneNumber = int.Parse(textBoxNumber.Text);

            EditUser(_userInfo);
            this.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure You want to delete this user?", "Deleting user", MessageBoxButtons.YesNo);

            if(result == DialogResult.Yes)
            {
                DeleteUser(_userInfo);
                this.Close();
            }
        }
    }
}
