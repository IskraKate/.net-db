﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class AddPerson : FormAllInfo
    {
        FormNameList.PersonInfo _personInfo;
        private delegate void AddPersonHandler(FormNameList.PersonInfo personInfo);
        private event AddPersonHandler AddPersonEvent;
        string path;

        public AddPerson()
        {
            InitializeComponent();
        }

        public AddPerson(FormNameList formNameList)
        {
            InitializeComponent();
            this.AddPersonEvent += formNameList.AddPerson;
            this.FormClosed += AddPerson_FormClosed;
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

            if(ofd.ShowDialog() == DialogResult.OK)
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
            if(personPhoto.Image != null && personName.Text != "" && personSurname.Text!= "" && personPatronymic.Text != "")
            {
                path = @"C:\Users\Iskra\source\repos\bpu-1821-homework\.net-db\01-Connected Layer\02-Connected Layer\HumanResourcesDepartment\PersonalPhotos\" + personName.Text + personSurname.Text + personPatronymic.Text + ".jpeg";
                personPhoto.Image.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);

                this.Close();
            }
            else
            {
                MessageBox.Show("Cannot save the file check that all fields are filled", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddPersonEvent(_personInfo);

            string sqlString = "INSERT INTO Persons(FirstName, LastName, Patronymic, Birthday, ContractNumber, DismissalNumber, PhotoPath) VALUES (@FirstName, @LastName, @Patronymic, @Birthday, @ContractNumber, @DismissalNumber, @PhotoPath)";
            using (SqlCommand command = new SqlCommand(sqlString, FormNameList.connection))
            {
                command.Parameters.Add(new SqlParameter("@Firstname", personName.Text));
                command.Parameters.Add(new SqlParameter("@LastName", personSurname.Text));
                command.Parameters.Add(new SqlParameter("@Patronymic", personPatronymic.Text));
                command.Parameters.Add(new SqlParameter("@Birthday", birthadyDateTimePicker.Value));
                command.Parameters.Add(new SqlParameter("@ContractNumber", personContractNumber.Text));
                command.Parameters.Add(new SqlParameter("@DismissalNumber", personDismissalNumber.Text));
                command.Parameters.Add(new SqlParameter("@PhotoPath", path));
                command.ExecuteNonQuery();
            }

        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}