using HumanResourcesDepartment._02_View.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormAddPerson : FormAllInfo, IAdd
    {
        private string _path;

        public event AddHandler AddEvent;

        public FormAddPerson()
        {
            InitializeComponent();
        }

        public FormAddPerson(FormNameList formNameList)
        {
            InitializeComponent();

            #region Controls settings
            birthadyDateTimePicker.Format = DateTimePickerFormat.Custom;
            birthadyDateTimePicker.Enabled = true;

            buttonEdit.Enabled = false;
            buttonEddited.Enabled = false;

            buttonEdit.Visible = false;
            buttonEddited.Visible = false;

            personName.ReadOnly = false;
            personSurname.ReadOnly = false;
            personPatronymic.ReadOnly = false;
            personContractNumber.ReadOnly = false;
            personDismissalNumber.ReadOnly = false;
            #endregion
        }

        private void AddPerson_Load(object sender, EventArgs e)
        {

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
                _path = personName.Text + personSurname.Text + personPatronymic.Text + ".jpeg";

                if (personPhoto.Image != null)
                    personPhoto.Image.Save(_path, System.Drawing.Imaging.ImageFormat.Jpeg);

                AddEvent?.Invoke(personName.Text, personSurname.Text, personPatronymic.Text, int.Parse(personDismissalNumber.Text), int.Parse(personContractNumber.Text),
                    birthadyDateTimePicker.Value, _path);

                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
