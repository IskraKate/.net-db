﻿using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormAllInfo : Form, IView
    {
        public event EventHandler ViewEvent;

        private int _index;
        private string _path = "";

        public List<PersonInfo> PersonInfo { get; set; }

        public PersonInfo CurrentPerson { get { return PersonInfo[_index]; } }

        public FormAllInfo()
        {
            InitializeComponent();
        }

        public FormAllInfo(FormNameList formNameList, List<PersonInfo> personInfo, int index)
        {
            InitializeComponent();
            PersonInfo = personInfo;
            _index = index;
            PersonAllInfoShow();

            personName.HideSelection = true;
        }

        private void PersonAllInfoShow()
        {
            personName.Text = PersonInfo[_index].FirstName;
            personSurname.Text = PersonInfo[_index].LastName;
            personPatronymic.Text = PersonInfo[_index].Patronymic;
            personContractNumber.Text = PersonInfo[_index].ContractNumber.ToString();
            personDismissalNumber.Text = PersonInfo[_index].DismissalNumber.ToString();
            birthadyDateTimePicker.Value = PersonInfo[_index].Birthday;

            if(!String.IsNullOrEmpty(PersonInfo[_index].PhotoPath) && File.Exists(PersonInfo[_index].PhotoPath))
            {
                personPhoto.Image = new Bitmap(PersonInfo[_index].PhotoPath);
            }

            birthadyDateTimePicker.Format = DateTimePickerFormat.Custom;

            if (!string.IsNullOrEmpty(PersonInfo[_index].PhotoPath))
            {
                if(File.Exists(PersonInfo[_index].PhotoPath))
                personPhoto.Image = new Bitmap(PersonInfo[_index].PhotoPath);
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

            buttonDownloadPhoto.Enabled = true;
            buttonDownloadPhoto.Visible = true;
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
                _path = PersonInfo[_index].FirstName + PersonInfo[_index].LastName + ".jpg";
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

                PersonInfo[_index].FirstName = personName.Text;
                PersonInfo[_index].LastName = personSurname.Text;
                PersonInfo[_index].Patronymic = personPatronymic.Text;
                PersonInfo[_index].ContractNumber = int.Parse(personContractNumber.Text);
                PersonInfo[_index].DismissalNumber = int.Parse(personContractNumber.Text);
                PersonInfo[_index].Birthday = birthadyDateTimePicker.Value;
                PersonInfo[_index].PhotoPath = _path;

                //ViewEvent?.Invoke(this, EventArgs.Empty);
                ViewEvent(this, EventArgs.Empty);

                this.Close();
            }
        }
    }
}