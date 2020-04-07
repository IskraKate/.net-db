using System;
using System.Windows.Forms;

namespace _03_LINQ_project
{
    public partial class FormAddContact : Form
    {
        private delegate void AddContactHandler(Telephones contact);
        private event AddContactHandler AddContact;

        public FormAddContact()
        {
            InitializeComponent();
        }

        public FormAddContact(FormTelephones form)
        {
            InitializeComponent();
            AddContact += form.AddContact;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Telephones contact = new Telephones();
            contact.Name = textBoxName.Text;
            contact.Telephone = int.Parse(textBoxTelephone.Text);
            AddContact(contact);
            this.Close();
        }

        private void FormAddingContact_Load(object sender, EventArgs e)
        {

        }
    }
}
