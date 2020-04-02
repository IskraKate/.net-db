using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class FullUserInfoForm : Form
    {
        User _userInfo;

        public FullUserInfoForm()
        {
            InitializeComponent();
        }

        public FullUserInfoForm(Users usersList)
        {
            InitializeComponent();
            
        }

        public void UserFullInfoShow(User user)
        {
            _userInfo = user;
            textBoxLogin.Text = _userInfo.Login;
            textBoxPassword.Text = _userInfo.Password;
            textBoxAddress.Text = _userInfo.Address;
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
        }

        private void buttonEditted_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FullUserInfoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
