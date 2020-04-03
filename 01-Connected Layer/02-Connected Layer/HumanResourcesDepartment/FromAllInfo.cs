using System;
using System.Drawing;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormAllInfo : Form
    {
        private delegate void PersonEdittedHandler(FormNameList.PersonInfo personInfoEddited);
        private event PersonEdittedHandler PersonEddited;
        private FormNameList.PersonInfo _personInfo;
        public FormAllInfo()
        {
            InitializeComponent();
        }

        public FormAllInfo(FormNameList formNameList)
        {
            InitializeComponent();
            PersonEddited += formNameList.personInfoEddited_FormAllInfo;
            personName.HideSelection = true;
        }

        public void PersonAllInfoShow(FormNameList.PersonInfo personInfo)
        {
            _personInfo = personInfo;
            personName.Text = personInfo.FirstName;
            personSurname.Text = personInfo.LastName;
            personPatronymic.Text = personInfo.Patronymic;
            personContractNumber.Text = personInfo.ContractNumber.ToString();
            personDismissalNumber.Text = personInfo.ContractNumber.ToString();
            birthadyDateTimePicker.Value = personInfo.Birthday;
            birthadyDateTimePicker.Format = DateTimePickerFormat.Custom;

            if (personInfo.PhotoPath != "")
            {
                personPhoto.Image = new Bitmap(personInfo.PhotoPath);
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
            if(dlgRslt == DialogResult.OK)
            {
                buttonEdit.Enabled = true;
                buttonEddited.Enabled = false;
                _personInfo.FirstName = personName.Text;
                _personInfo.LastName = personSurname.Text;
                _personInfo.Patronymic = personPatronymic.Text;
                _personInfo.ContractNumber = int.Parse(personContractNumber.Text);
                _personInfo.DismissalNumber = int.Parse(personContractNumber.Text);
                _personInfo.Birthday = birthadyDateTimePicker.Value;
                PersonEddited(_personInfo);
            }
        }
    }
}
