using _01_Disconnected_layer_proj._02_View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class AddForm : FullUserInfoForm, IView
    {
        public new event EventHandler ViewEvent;

        public new List<User> UserList { get; set; }

        public AddForm(List<User> userList)
        {
            InitializeComponent();
            UserList = userList;
        }

        public new bool Check()
        {
            for (int i = 0; i < UserList.Count - 1; i++)
            {
                if (!CheckUnique(textBoxLogin.Text, UserList[i].Login))
                {
                    return false;
                }
            }
            return true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != string.Empty && textBoxPassword.Text != string.Empty && textBoxAddress.Text != string.Empty && textBoxNumber.Text != string.Empty)
            {
                UserList.Add(new User
                {
                    Login = textBoxLogin.Text,
                    Password = textBoxPassword.Text,
                    Address = textBoxAddress.Text,
                    TelephoneNumber = long.Parse(textBoxNumber.Text),
                    IsAdmin = checkBoxAdmin.Checked
                });
            }
            else
            {
                MessageBox.Show("Please fill all of fields");
            }

            if (Check())
            {
                ViewEvent?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            else
            {
                UserList.Remove(UserList.Last());
                MessageBox.Show("Login is not unique");
            }
                
        }

        #region ParentValidatingEvents

        private void textBoxLogin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void textBoxPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void textBoxAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void textBoxNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        #endregion

        #region ParentValidatedEnets

        private void textBoxNumber_Validated(object sender, EventArgs e)
        {

        }

        private void textBoxAddress_Validated(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_Validated(object sender, EventArgs e)
        {

        }

        private void textBoxLogin_Validated(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
