using _01_Disconnected_layer_proj._02_View;
using _01_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class FullUserInfoForm : Form, IView, IDelete, IValidate
    {
        public List<User> UserList { get; set; }
        public User CurrentPerson { get { return UserList[_index]; } }

        private int _index;

        public event EventHandler ViewEvent;
        public event EventHandler DeleteEvent;

        public FullUserInfoForm()
        {
            InitializeComponent();
        }

        public FullUserInfoForm(Users usersList, List<User> user, int index)
        {
            InitializeComponent();

            textBoxPassword.UseSystemPasswordChar = true;

            UserList = user;
            _index = index;


            textBoxLogin.Text = UserList[_index].Login;
            textBoxPassword.Text = UserList[_index].Password; 
            textBoxAddress.Text = UserList[_index].Address;
            checkBoxAdmin.Checked = UserList[_index].IsAdmin;
            textBoxNumber.Text = UserList[_index].TelephoneNumber.ToString();
        }

        public bool Check()
        {
            for (int i = 0; i < UserList.Count - 1; i++)
            {
                if (!CheckUnique(textBoxLogin.Text, UserList[i].Login) && i != _index)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckUnique(string login, string newLogin)
        {
            if (newLogin == login)
                return false;
            else
                return true;
        }

        private void buttonEditted_Click(object sender, EventArgs e)
        {
            UserList[_index].Login = textBoxLogin.Text;

            if (Check())
            {
                
                UserList[_index].Password = textBoxPassword.Text;
                UserList[_index].Address = textBoxAddress.Text;
                UserList[_index].TelephoneNumber = int.Parse(textBoxNumber.Text);

                ViewEvent?.Invoke(this, EventArgs.Empty);

                this.Close();
            }
            else
            {
                MessageBox.Show("Login is not unique");
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure You want to delete this user?", "Deleting user", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DeleteEvent?.Invoke(this, EventArgs.Empty);
                UserList.RemoveAt(_index);
                this.Close();
            }
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

        private void textBoxPassword_MouseClick(object sender, MouseEventArgs e)
        {
            if (!textBoxPassword.ReadOnly)
            {
                textBoxPassword.Text = "";
            }
        }


        #region Valid Methods

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the email address string is not empty.
            if (emailAddress.Length == 0)
            {
                errorMessage = "email address is required.";
                return false;
            }

            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "email address must be valid email address format.\n" +
               "For example 'someone@example.com' ";
            return false;
        }

        public bool ValidLogin(string login, out string errorMessage)
        {
            if(login.Length==0)
            {
                errorMessage = "login is required.";
                return false;
            }

            if(Char.IsDigit(login[0]))
            {
                errorMessage = "the first symbol can`t be a digit.";
                return false;
            }

            if(login.Length < 6)
            {
                errorMessage = "maximum size is 16 symbols\n";
            }

            if (login.Length > 15)
            {
                errorMessage = "maximum size is 15 symbols\n";
            }

            foreach (var chr in login)
            {
                if (!Char.IsLetterOrDigit(chr))
                {
                    break;
                }

                if(chr.Equals(login.Last()))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "login must be valid  login format.\n" +
                              "Use digits, (small/big)letters ";
            return false;
        }

        public bool ValidPassword(string password, out string errorMessage)
        {
            if (password.Length == 0)
            {
                errorMessage = "password is required.";
                return false;
            }

            if(password.Length < 6)
            {
                errorMessage = "minimum size is 6 symbols\n";
            }

            if (password.Length > 15)
            {
                errorMessage = "maximum size is 15 symbols\n";
            }

            foreach (var chr in password)
            {
                if (!Char.IsLetterOrDigit(chr))
                {
                    break;
                }

                if (chr.Equals(password.Last()))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "password must be valid password format.\n" +
                              "Use digits, (small/big)letters ";
            return false;
        }

        public bool ValidTelephoneNumber(string number, out string errorMessage)
        {
            if (number.Length == 0)
            {
                errorMessage = "password is required.";
                return false;
            }
            
            if(number.Length > 9)
            {
                errorMessage = "";
                return false;
            }

            foreach (var num in number)
            {
                if (!Char.IsDigit(num))
                {
                    break;
                }

                if (num.Equals(number.Last()))
                {
                    errorMessage = "";
                    return true;
                }
            }

            errorMessage = "telephone number must be valid telephonenumber format.\n" +
                           "Use digits";
            return false;
        }

        #endregion

        #region Validating Events

        protected void textBoxAddress_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidEmailAddress(textBoxAddress.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBoxAddress.Select(0, textBoxAddress.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBoxAddress, errorMsg);
            }
        }

        protected void textBoxLogin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidLogin(textBoxLogin.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBoxPassword.Select(0, textBoxLogin.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBoxLogin, errorMsg);
            }
        }

        protected void textBoxPassword_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidPassword(textBoxPassword.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBoxPassword.Select(0, textBoxPassword.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBoxPassword, errorMsg);
            }
        }

        protected void textBoxNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string errorMsg;
            if (!ValidTelephoneNumber(textBoxNumber.Text, out errorMsg))
            {
                // Cancel the event and select the text to be corrected by the user.
                e.Cancel = true;
                textBoxNumber.Select(0, textBoxNumber.Text.Length);

                // Set the ErrorProvider error with the text to display. 
                this.errorProvider1.SetError(textBoxNumber, errorMsg);
            }
        }

        #endregion

        #region Validated Events

        protected void textBoxAddress_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBoxAddress, "");
        }

        protected void textBoxLogin_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBoxLogin, "");
        }

        protected void textBoxPassword_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBoxPassword, "");
        }

        protected void textBoxNumber_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError(textBoxNumber, "");
        }

        #endregion

    }
}
