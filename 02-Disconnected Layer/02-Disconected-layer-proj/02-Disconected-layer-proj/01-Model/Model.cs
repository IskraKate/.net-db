﻿using _02_Disconected_layer_proj._01_Model.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace _02_Disconected_layer_proj._01_Model
{
    class Model: IModel
    {
        private static IModel _model = new Model();

        private string _connectionString;
        private SqlConnection _sqlConnection;
        private DataSet _dataSet ;
        private SqlDataAdapter _sqlDataAdapter;
        private string _commandSelect;

        private Model()
        {
            _connectionString = "Data Source=(local);Initial Catalog=BooksAuthorsPresses;Integrated Security=True";
            _dataSet = new DataSet("BooksAuthorsPresses");
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlDataAdapter = new SqlDataAdapter();
        }

        public static IModel GetModel
        {
            get
            {
                return _model;
            }
        }

        public List<Author> FillAuthorsList(List<Author> authors)
        {
            _commandSelect = "SELECT Id, Name FROM Authors";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_commandSelect, _sqlConnection);

            _dataSet.Clear();
            _sqlDataAdapter.Fill(_dataSet);
            authors.Clear();

            authors = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Author
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            return authors;
        }

        public List<Book> FillBooksList(List<Book> books)
        {
            _commandSelect = "SELECT Books.Id, Title, AuthorFk, PressFk FROM Books, Authors, Presses" +
                   " WHERE AuthorFk=Authors.Id AND PressFk = Presses.Id";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_commandSelect, _sqlConnection);

            _dataSet.Clear();
            _sqlDataAdapter.Fill(_dataSet);
            books.Clear();

            books = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Book
            {
                Id = dataRow.Field<long>("Id"),
                Title = dataRow.Field<string>("Title"),

                AuthorFk = dataRow.Field<long>("AuthorFk"),
                PressFk = dataRow.Field<long>("PressFk")
            }).ToList();

            return books;
        }

        public List<Press> FillPressesList(List<Press> presses)
        {
            _commandSelect = "SELECT Id, Name FROM Presses";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_commandSelect, _sqlConnection);

            _dataSet.Clear();
            _sqlDataAdapter.Fill(_dataSet);
            presses.Clear();

            presses = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Press
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            return presses;
        }
    }
}
