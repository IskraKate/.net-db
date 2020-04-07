using System;
using System.Windows.Forms;

namespace _03_LINQ_project
{
    public partial class FormEdit : FormAddContact
    {

        private delegate void EditContactHandler(Telephones contact);
        private event EditContactHandler EditContact;
        private Telephones _contact;

        public FormEdit()
        {
            InitializeComponent();
        }

        public FormEdit(FormTelephones form, Telephones contact)
        {
            InitializeComponent();
            EditContact += form.EditContact;
            textBoxName.Text = contact.Name;
            textBoxTelephone.Text = contact.Telephone.ToString();
            _contact = contact;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            var dlg = MessageBox.Show("Are you sure, you want edit the contact?", "Want to edit???", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlg == DialogResult.OK)
            {
                _contact.Name = textBoxName.Text;
                _contact.Telephone = int.Parse(textBoxTelephone.Text);
                EditContact(_contact);
                this.Close();
            }
        }
    }
}
