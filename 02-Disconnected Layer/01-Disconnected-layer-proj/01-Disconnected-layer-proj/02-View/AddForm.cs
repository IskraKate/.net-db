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
    public partial class AddForm : FullUserInfoForm
    {
        private delegate bool CheckUniqueHandler(string login);
        private event CheckUniqueHandler CheckUnique;

        private delegate void AddUserHandler(User user);
        private event AddUserHandler AddUser;
        
        public AddForm(Users usersList)
        {
            InitializeComponent();

            CheckUnique += usersList.CheckUnique;
            AddUser += usersList.AddUser;
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text != string.Empty && textBoxPassword.Text != string.Empty && textBoxAddress.Text != string.Empty && textBoxNumber.Text != string.Empty)
            {
                if (CheckUnique(textBoxLogin.Text))
                {
                    User user = new User
                    {
                        Login = textBoxLogin.Text,
                        Password = textBoxPassword.Text,
                        Address = textBoxAddress.Text,
                        TelephoneNumber = long.Parse(textBoxNumber.Text),
                        IsAdmin = checkBoxAdmin.Checked
                    };
                    this.Close();
                    AddUser(user);
                }
                else
                {
                    MessageBox.Show("Logis is not unique");
                }
            }
            else
            {
                MessageBox.Show("Please fill all of fields");
            }
       
        }
    }
}
