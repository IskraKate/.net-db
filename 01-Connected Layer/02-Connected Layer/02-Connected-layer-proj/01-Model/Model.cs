using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HumanResourcesDepartment.ModelNamespace
{
    class Model : IModel, IDisposable
    {
        private static IModel _model = new Model();

        private SqlConnection _connection = new SqlConnection();
        private List<PersonInfo> _infos = new List<PersonInfo>();
        private string _sqlString;

        private Model()
        {

        }

        static public IModel GetModel()
        {
            return _model;
        }

        public void Connect()
        {
            SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = "(local)";
            _builder.InitialCatalog = "HumanResources";
            _builder.IntegratedSecurity = true;
            _connection.ConnectionString = _builder.ConnectionString;
            try
            {
               _connection.Open();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public List<PersonInfo> FillList()
        {
            _infos.Clear();
            _sqlString = "ShowPersons";

            using (SqlCommand command = new SqlCommand(_sqlString, _connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = command.ExecuteReader())
                { 
                    while (reader.Read())
                    {
                        _infos.Add(new PersonInfo
                        {
                            Id = int.Parse(reader["Id"].ToString()),
                            FirstName = (string)reader["Firstname"],
                            LastName = ((string)reader["Lastname"]),
                            Patronymic = ((string)reader["Patronymic"]),
                            Birthday = (DateTime)reader["Birthday"],
                            ContractNumber = int.Parse(reader["ContractNumber"].ToString()),
                            DismissalNumber = int.Parse(reader["DismissalNumber"].ToString()),
                            PhotoPath = (reader["PhotoPath"]) != System.DBNull.Value ? ((string)reader["PhotoPath"]) : string.Empty
                        });
                    }
                    reader.Close();
                }
                return _infos;
            }
        }

        public void AddPersonToBase(PersonInfo personInfo)
        {
            _sqlString = "AddPerson";
            using (SqlCommand command = new SqlCommand(_sqlString, _connection))
            {
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@Firstname", personInfo.FirstName));
                command.Parameters.Add(new SqlParameter("@LastName", personInfo.LastName));
                command.Parameters.Add(new SqlParameter("@Patronymic", personInfo.Patronymic));
                command.Parameters.Add(new SqlParameter("@Birthday", personInfo.Birthday));
                command.Parameters.Add(new SqlParameter("@ContractNumber", personInfo.ContractNumber));
                command.Parameters.Add(new SqlParameter("@DismissalNumber", personInfo.DismissalNumber));
                if(!String.IsNullOrEmpty(personInfo.PhotoPath))
                {
                    command.Parameters.Add(new SqlParameter("@PhotoPath", personInfo.PhotoPath));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter("@PhotoPath", "NULL"));
                }
                command.ExecuteNonQuery();
            }
        }

        public void EditPerson(PersonInfo personInfoEdited)
        {
            try
            {
                _sqlString = "EditPerson";
                using (SqlCommand command = new SqlCommand(_sqlString, _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", personInfoEdited.Id));
                    command.Parameters.Add(new SqlParameter("@FirstName", personInfoEdited.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", personInfoEdited.LastName));
                    command.Parameters.Add(new SqlParameter("@Patronymic", personInfoEdited.Patronymic));
                    command.Parameters.Add(new SqlParameter("@Birthday", personInfoEdited.Birthday));
                    command.Parameters.Add(new SqlParameter("@ContractNumber", personInfoEdited.ContractNumber));
                    command.Parameters.Add(new SqlParameter("@DismissalNumber", personInfoEdited.DismissalNumber));

                    if(!String.IsNullOrEmpty(personInfoEdited.PhotoPath))
                    {
                        command.Parameters.Add(new SqlParameter("@PhotoPath", personInfoEdited.PhotoPath));
                    }

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Delete(int index)
        {
            try
            {
                _sqlString = "DeletePerson";
                using (SqlCommand command = new SqlCommand(_sqlString, _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", index));
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

         public void Dispose()
        {
            if (_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
