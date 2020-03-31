using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormNameList : Form
    {
        public static SqlConnection connection = new SqlConnection();
        public List<PersonInfo> infos = new List<PersonInfo>();
        string _sqlString = "SELECT Persons.Id, Persons.FirstName, Persons.LastName, Persons.Patronymic, Persons.Birthday, Persons.ContractNumber,                                                              Persons.DismissalNumber, Persons.PhotoPath " +
                            "FROM Persons";
        private delegate void PersonAllInfoHadler(PersonInfo personInfo);
        private event PersonAllInfoHadler PersonAllInfoEvent;

        public List<PersonInfo> Infos
        {
            get
            {
                return infos;
            }
        }

        public ListView GetListView
        {
            get
            {
                return listViewNames;
            }
        }

        public FormNameList()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = "(local)";
            _builder.InitialCatalog = "HumanResources";
            _builder.IntegratedSecurity = true;

            connection.ConnectionString = _builder.ConnectionString;
            try
            {
                connection.Open();
                FillListInfo();
                FillListView();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }

        public struct PersonInfo
        {
            public int Id { get; internal set; }
            public string FirstName;
            public string LastName;
            public string Patronymic;
            public int ContractNumber;
            public int DismissalNumber;
            public DateTime Birthday;
            public string PhotoPath;
        }

        public void FillListInfo()
        {
            using (SqlCommand command = new SqlCommand(_sqlString, connection))
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    infos.Add(new PersonInfo
                    {
                        Id = int.Parse(reader["Id"].ToString()),
                        FirstName = (string)reader["Firstname"],
                        LastName = ((string)reader["Lastname"]),
                        Patronymic = ((string)reader["Patronymic"]),
                        Birthday =  (DateTime)reader["Birthday"],
                        ContractNumber = int.Parse(reader["ContractNumber"].ToString()),
                        DismissalNumber = int.Parse(reader["DismissalNumber"].ToString()),
                        PhotoPath = (reader["PhotoPath"]) != System.DBNull.Value ? ((string)reader["PhotoPath"]) : string.Empty
                    });
                }
                reader.Close();
            }
        }

        public void FillListView()
        {
            try
            {
                using (SqlCommand command = new SqlCommand(_sqlString, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    foreach (var info in infos)
                    {
                        var listViewItem = listViewNames.Items.Add(new ListViewItem());
                        listViewItem.Text = info.FirstName +' '+ info.LastName + ' ' + info.Patronymic;
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void RefreshListView()
        {
            listViewNames.Items.Clear();
            infos.Clear();
            FillListInfo();
            FillListView();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addPerson = new AddPerson(this);
            addPerson.ShowDialog();
        }

        public void AddPerson(PersonInfo personInfo)
        {
            infos.Add(personInfo);
            var listViewItem = listViewNames.Items.Add(new ListViewItem());
            listViewItem.Text = personInfo.FirstName + ' ' + infos.Last().LastName + ' ' + infos.Last().Patronymic;
            Refresh();
        }

        public void personInfoEddited_FormAllInfo(PersonInfo personInfoEddited)
        {
            for (int i = 0; i < infos.Count; i++)
            {
                if (infos[i].Id == personInfoEddited.Id)
                {
                    infos[i] = personInfoEddited;
                    var listViewItem = listViewNames.SelectedItems[0];
                    listViewItem.Text = infos[i].FirstName + ' ' + infos[i].LastName + ' ' + infos[i].Patronymic;
                    break;
                }
            }

            try
            {
                string sqlString = "UPDATE Persons SET FirstName = @FirstName, LastName = @LastName, Patronymic = @Patronymic, Birthday = @Birthday, ContractNumber = @ContractNumber, DismissalNumber = @DismissalNumber WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(sqlString, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id",              personInfoEddited.Id));
                    command.Parameters.Add(new SqlParameter("@FirstName",       personInfoEddited.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName",        personInfoEddited.LastName));
                    command.Parameters.Add(new SqlParameter("@Patronymic",      personInfoEddited.Patronymic));
                    command.Parameters.Add(new SqlParameter("@Birthday",        personInfoEddited.Birthday));
                    command.Parameters.Add(new SqlParameter("@ContractNumber",  personInfoEddited.ContractNumber));
                    command.Parameters.Add(new SqlParameter("@DismissalNumber", personInfoEddited.DismissalNumber));
                    command.ExecuteNonQuery();
                }
                Refresh();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void listViewNames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewNames.SelectedItems.Count > 0)
            {
                int index;
                var formAllInfo = new FormAllInfo(this);
                PersonAllInfoEvent += formAllInfo.PersonAllInfoShow;
                index = listViewNames.Items.IndexOf(listViewNames.SelectedItems[0]);
                PersonAllInfoEvent(infos[index]);
                formAllInfo.ShowDialog();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dlgRslt = MessageBox.Show("Do you want to delete this person from list?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlgRslt == DialogResult.OK && listViewNames.SelectedItems.Count > 0)
            {
                try
                {
                    string sqlString = "DELETE FROM Persons WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(sqlString, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Id", infos[listViewNames.SelectedItems[0].Index].Id));
                        command.ExecuteNonQuery();
                    }
                    infos.RemoveAt(listViewNames.SelectedItems[0].Index);
                    listViewNames.Items[listViewNames.SelectedItems[0].Index].Remove();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            Refresh();
        }

        private void FormNameList_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
        }
    }
}
