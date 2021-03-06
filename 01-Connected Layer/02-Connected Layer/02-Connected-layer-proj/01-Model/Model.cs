﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace HumanResourcesDepartment.ModelNamespace
{
    class Model : IModel, IDisposable
    {
        private static IModel _model = new Model();

        private SqlConnection _connection = new SqlConnection();
        private List<PersonInfo> _infos = new List<PersonInfo>();
        private string _sqlString = string.Empty;

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
            catch(SqlException ex){}
        }

        public List<PersonInfo> FillList()
        {
            _infos.Clear();
            _sqlString = "ShowPeople";

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

        public List<PersonInfo> GetInfo()
        {
            return _infos;
        }

        public void AddPersonToBase(PersonInfo personInfo)
        {
            _infos.Add(personInfo);

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

        public void EditPerson(List<PersonInfo> infos, int index)
        {
            try
            {
                _infos = infos;
                _sqlString = "EditPerson";
                using (SqlCommand command = new SqlCommand(_sqlString, _connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", _infos[index].Id));
                    command.Parameters.Add(new SqlParameter("@FirstName", _infos[index].FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", _infos[index].LastName));
                    command.Parameters.Add(new SqlParameter("@Patronymic", _infos[index].Patronymic));
                    command.Parameters.Add(new SqlParameter("@Birthday", _infos[index].Birthday));
                    command.Parameters.Add(new SqlParameter("@ContractNumber", _infos[index].ContractNumber));
                    command.Parameters.Add(new SqlParameter("@DismissalNumber", _infos[index].DismissalNumber));

                    if(!String.IsNullOrEmpty(_infos[index].PhotoPath))
                    {
                        command.Parameters.Add(new SqlParameter("@PhotoPath", _infos[index].PhotoPath));
                    }
                    else
                    {
                        command.Parameters.Add(new SqlParameter("@PhotoPath", String.Empty));
                    }

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) {}
        }

        public void Delete(int index)
        {
            try
            {
                _sqlString = "DeletePerson";
                using (SqlCommand command = new SqlCommand(_sqlString, _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", _infos[index].Id));
                    command.ExecuteNonQuery();
                }

                _infos.RemoveAt(index);
            }
            catch (SqlException ex){}
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
