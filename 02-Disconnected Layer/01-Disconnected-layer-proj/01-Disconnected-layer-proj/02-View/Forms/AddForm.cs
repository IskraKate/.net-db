using _01_Disconnected_layer_proj._02_View.Interfaces;
using System;

namespace _01_Disconnected_layer_proj
{
    public partial class AddForm : FullUserInfoForm, IViewAdd
    {
        public event AddHandler AddEvent;

        public AddForm()
        {
            InitializeComponent();
            textBoxPassword.UseSystemPasswordChar = true;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddEvent?.Invoke();
            this.Close();
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
