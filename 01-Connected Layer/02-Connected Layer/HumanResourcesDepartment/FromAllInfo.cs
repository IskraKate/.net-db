using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormAllInfo : Form
    {
        public FormAllInfo()
        {
            InitializeComponent();
        }

        public FormAllInfo(FormNameList formNameList)
        {
            InitializeComponent();
            personName.HideSelection = true;
        }

        public void PersonAllInfoShow(FormNameList.PersonInfo personInfo)
        {
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
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
