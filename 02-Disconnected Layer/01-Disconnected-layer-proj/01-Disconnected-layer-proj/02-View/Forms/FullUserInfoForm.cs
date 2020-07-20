using _01_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Linq;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class FullUserInfoForm : Form, IViewFullInfo, IDelete, IValidate
    {
        private int _index;
        private string _text;

        public string Login
        {
            get
            {
                return textBoxLogin.Text;
            }
            set
            {
                textBoxLogin.Text = value;
            }
        }

        public string Password
        {
            get
            {
                return textBoxPassword.Text;
            }
            set
            {
                textBoxPassword.Text = value;
            }
        }
        public string Email
        {
            get
            {
                return textBoxAddress.Text;
            }
            set
            {
                textBoxAddress.Text = value;
            }
        }
        public bool IsAdmin
        {
            get
            {
                return checkBoxAdmin.Checked;
            }
            set
            {
                checkBoxAdmin.Checked = value;
            }
        }
        public string Telephone
        {
            get
            {
                return textBoxNumber.Text;
            }
            set
            {
                textBoxNumber.Text = value;
            }
        }

        public bool LoginChecked { get; set; }

        public event EventHandler DeleteEvent;
        public event ViewHandler ViewEvent;
        public event EditHandler EditEvent;

        public FullUserInfoForm()
        {
            InitializeComponent();
        }

        public FullUserInfoForm(int index)
        {
            InitializeComponent();

            textBoxPassword.UseSystemPasswordChar = true;

            _index = index;
        }

        private void buttonEditted_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure You want to update info?", "Updating info", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                EditEvent?.Invoke();

                if (!LoginChecked)
                {
                    MessageBox.Show("Your Login is not unique");
                    textBoxLogin.Text = _text;
                    LoginChecked = true;
                    this.Show();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are You sure You want to delete this user?", "Deleting user", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                DeleteEvent?.Invoke(this, EventArgs.Empty);
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

            _text = textBoxLogin.Text;
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
            errorMessage = "";
            if (number.Length == 0)
            {
                errorMessage = "telephone number is required.";
                return false;
            }

            if(number.Length > 9)
            {
                errorMessage = "telephone number is longer then can be.";
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

            errorMessage = "telephone number must be valid telephone number format.\n" +
                           "use digits";
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

        private void FullUserInfoForm_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(_index);
        }
    }
}
