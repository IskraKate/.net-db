using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using _01_Disconnected_layer_proj._03_Presenter;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class Users : Form, IView
    {
        public List<User> UserList{ get; set; }

        public event EventHandler ViewEvent;

        public Users()
        {
            InitializeComponent();
            UserList = new List<User>();
        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            var addForm = new AddForm(UserList);
            var AddFormPresenter = new AddFormPresenter(addForm, Model.GetModel());
            addForm.ShowDialog();
            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillListBox();
        }

        public void FillListBox()
        {
            if(listBoxUsers.Items.Count>0)
            listBoxUsers.Items.Clear();

            foreach (var user in UserList)
            {
                if (checkBoxAdminShower.Checked)
                    listBoxUsers.Items.Add(user.Login);
                else
                {
                    if(user.IsAdmin)
                        continue;
                    else
                        listBoxUsers.Items.Add(user.Login);
                }
            }
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
                var fullUserInfoForm = new FullUserInfoForm(this, UserList, listBoxUsers.SelectedIndex);
                var fullUserListPresenter = new FullUserListPresenter(fullUserInfoForm, Model.GetModel());
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
