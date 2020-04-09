using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class AddPerson : FormAllInfo
    {
        private delegate void AddPersonHandler(PersonInfo personInfo);
        private event AddPersonHandler AddPersonEvent;
        string path;
        PersonInfo _personInfo = new PersonInfo();

        public AddPerson()
        {
            InitializeComponent();
        }

        public AddPerson(FormNameList formNameList)
        {
            InitializeComponent();
            this.AddPersonEvent += formNameList.AddPerson;
            birthadyDateTimePicker.Format = DateTimePickerFormat.Custom;
            birthadyDateTimePicker.Enabled = true;
            buttonEdit.Enabled = false;
            buttonEddited.Enabled = false;
            buttonEdit.Visible = false;
            buttonEddited.Visible = false;
        }

        private void AddPerson_Load(object sender, EventArgs e)
        {
            personName.ReadOnly = false;
            personSurname.ReadOnly = false;
            personPatronymic.ReadOnly = false;
            personContractNumber.ReadOnly = false;
            personDismissalNumber.ReadOnly = false;
        }

        private void downloadPhoto_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP, *.JPEG, *JPG, *.PNG, *.GIF)|*.BMP; *.JPEG; *JPG; *.PNG; *.GIF|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    personPhoto.Image = new Bitmap(ofd.FileName);
                }
                catch
                {
                    MessageBox.Show("Cannot open the file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                path = @"PersonPhotos\" + personName.Text + personSurname.Text + personPatronymic.Text + ".jpeg";

                if(personPhoto.Image != null)
                personPhoto.Image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                _personInfo.FirstName = personName.Text;
                _personInfo.LastName = personSurname.Text;
                _personInfo.Patronymic = personSurname.Text;
                _personInfo.Birthday = birthadyDateTimePicker.Value;
                _personInfo.ContractNumber = int.Parse(personContractNumber.Text);
                _personInfo.DismissalNumber = int.Parse(personDismissalNumber.Text);

                AddPersonEvent(_personInfo);
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
