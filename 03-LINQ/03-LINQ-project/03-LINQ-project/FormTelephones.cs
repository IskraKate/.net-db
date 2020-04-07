using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace _03_LINQ_project
{
    public partial class FormTelephones : Form
    {
        List<Telephones> _contactsList;

        public FormTelephones()
        {
            _contactsList = new List<Telephones>();
            InitializeComponent();
            //FillingWithTestElements();
            //CreateFile();
            ReadFromFile();
            FillListView();
        }

        public void FillListView()
        {
            listViewTelephones.Items.Clear();
            foreach (var contact in _contactsList)
            {
                var listViewItem = listViewTelephones.Items.Add(new ListViewItem());
                listViewItem.Text = contact.Name;
                listViewItem.SubItems.Add(contact.Telephone.ToString());
            }
        }

        public void ReadFromFile()
        {
            if (File.Exists(@"Telephones.dat"))
            {
                BinaryFormatter formatter = new BinaryFormatter();


                using (FileStream fs = new FileStream(@"Telephones.dat", FileMode.OpenOrCreate))
                {
                    _contactsList = formatter.Deserialize(fs) as List<Telephones>;
                }
            }
            else
            {
                return;
            }
        }

        public void CreateFile()
        {
            if(File.Exists(@"Telephones.dat"))
            {
                File.Delete(@"Telephones.dat");
            }

            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(@"Telephones.dat", FileMode.Create))
            {
                formatter.Serialize(fs, _contactsList);
            }
        }

        public void FillingWithTestElements()
        {
            _contactsList.Clear();

            #region Adding Elemets

            _contactsList.Add(new Telephones
            {
                Name = "8Some Name",
                Telephone = 0123456
            });

            _contactsList.Add(new Telephones
            {
                Name = "7Some Name2",
                Telephone = 7891011
            });

            _contactsList.Add(new Telephones
            {
                Name = "6Some Name3",
                Telephone = 1213141
            });

            _contactsList.Add(new Telephones
            {
                Name = "5Some Name3",
                Telephone = 2344231
            });

            _contactsList.Add(new Telephones
            {
                Name = "4Some Name4",
                Telephone = 0123312
            });

            _contactsList.Add(new Telephones
            {
                Name = "3Some Name5",
                Telephone = 0112216
            });

            #endregion
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                FormEdit formEdit = new FormEdit(this, _contactsList[listViewTelephones.SelectedIndices[0]]);
                formEdit.Show();
            }
            catch
            {
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            var dlg = MessageBox.Show("Are you sure, you want delete the contact?", "Want to delete???", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if(dlg == DialogResult.OK)
            {
                foreach (ListViewItem item in listViewTelephones.SelectedItems)
                {
                    _contactsList.RemoveAt(item.Index);
                    listViewTelephones.Items.Remove(item);
                }
                CreateFile();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddContact addContact = new FormAddContact(this);
            addContact.Show();
            CreateFile();
        }

        public void AddContact(Telephones contact)
        {
            _contactsList.Add(contact);
            FillListView();
        }

        public void EditContact(Telephones contacts)
        {
            ListViewItem listViewItem = listViewTelephones.SelectedItems[0];
            _contactsList[listViewItem.Index] = contacts;

            FillListView();

            CreateFile();
        }
    }
}
