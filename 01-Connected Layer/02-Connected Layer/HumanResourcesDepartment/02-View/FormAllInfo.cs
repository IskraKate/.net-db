using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormAllInfo : Form
    {
        private delegate void PersonEdittedHandler(PersonInfo personInfoEddited);
        private event PersonEdittedHandler PersonEdited;
        private PersonInfo _personInfo;

        public FormAllInfo()
        {
            InitializeComponent();
        }

        public FormAllInfo(FormNameList formNameList, PersonInfo personInfo)
        {
            InitializeComponent();
            _personInfo = personInfo;
            PersonAllInfoShow();
            PersonEdited += formNameList.personInfoEddited_FormAllInfo;
            personName.HideSelection = true;
        }

        private void PersonAllInfoShow()
        {
            personName.Text = _personInfo.FirstName;
            personSurname.Text = _personInfo.LastName;
            personPatronymic.Text = _personInfo.Patronymic;
            personContractNumber.Text = _personInfo.ContractNumber.ToString();
            personDismissalNumber.Text = _personInfo.ContractNumber.ToString();
            birthadyDateTimePicker.Value = _personInfo.Birthday;
            birthadyDateTimePicker.Format = DateTimePickerFormat.Custom;

            if (!string.IsNullOrEmpty(_personInfo.PhotoPath))
            {
                if(File.Exists(_personInfo.PhotoPath))
                personPhoto.Image = new Bitmap(_personInfo.PhotoPath);
            }
        }

        private void FormAllInfo_Load(object sender, EventArgs e)
        {
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            personName.ReadOnly = false;
            personSurname.ReadOnly = false;
            personPatronymic.ReadOnly = false;
            personContractNumber.ReadOnly = false;
            personDismissalNumber.ReadOnly = false;
            birthadyDateTimePicker.Enabled = true;
            buttonEddited.Enabled = true;
            buttonEdit.Enabled = false;
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
                _personInfo.FirstName = personName.Text;
                _personInfo.LastName = personSurname.Text;
                _personInfo.Patronymic = personPatronymic.Text;
                _personInfo.ContractNumber = int.Parse(personContractNumber.Text);
                _personInfo.DismissalNumber = int.Parse(personContractNumber.Text);
                _personInfo.Birthday = birthadyDateTimePicker.Value;
                PersonEdited(_personInfo);
                this.Close();
            }
        }
    }
}
