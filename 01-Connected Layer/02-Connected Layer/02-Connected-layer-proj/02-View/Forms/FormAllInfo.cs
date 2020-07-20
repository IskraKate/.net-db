using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment._03_Presenter;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormAllInfo : Form, IViewAllInfo
    {
        private int _index;
        private string _path = string.Empty;

        public string PersonName { get => personName.Text; set => personName.Text = value; }
        public string Surname { get => personSurname.Text; set => personSurname.Text = value; }
        public string Patronymic { get => personPatronymic.Text; set => personPatronymic.Text = value; }
        public string ContractNum { get => personContractNumber.Text; set => personContractNumber.Text = value; }
        public string DismissalNum { get => personDismissalNumber.Text; set => personDismissalNumber.Text = value; }
        public DateTime Birthday { get => birthadyDateTimePicker.Value; set => birthadyDateTimePicker.Value = value; }
        public string Path { get => _path; set => _path = value; }

        public event ViewAllInfoHandler ViewAllInfoEvent;
        public event EditedHandler EditedEvent;

        public FormAllInfo()
        {
            InitializeComponent();
        }

        public FormAllInfo(int index)
        {
            _index = index;
            var editPersonPresenter = new EditPersonPresenter(this);
            InitializeComponent();
            PersonAllInfoShow();

            personName.HideSelection = true;
        }

        private void PersonAllInfoShow()
        {
            ViewAllInfoEvent?.Invoke(_index);
            personPhoto.Image = new Bitmap(_path);
            birthadyDateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void FormAllInfo_Load(object sender, EventArgs e)
        {
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            #region buttons
            personName.ReadOnly = false;
            personSurname.ReadOnly = false;
            personPatronymic.ReadOnly = false;
            personContractNumber.ReadOnly = false;
            personDismissalNumber.ReadOnly = false;


            birthadyDateTimePicker.Enabled = true;

            buttonEddited.Enabled = true;

            buttonEdit.Enabled = false;

            buttonDownloadPhoto.Enabled = true;
            buttonDownloadPhoto.Visible = true;
            #endregion
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

            if (personPhoto.Image != null)
            {
                _path = personName.Text + personSurname.Text + ".jpg";
                personPhoto.Image.Save(_path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void buttonEddited_Click(object sender, EventArgs e)
        {
            DialogResult dlgRslt = MessageBox.Show("Do you really want to edit the item?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlgRslt == DialogResult.OK)
            {
               buttonEdit.Enabled = true;
                buttonEddited.Enabled = false;

                EditedEvent?.Invoke();

                 this.Close();
            }
        }
    }
}
