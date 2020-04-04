using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace _02_Disconected_layer_proj
{
    public struct Book
    {
        public long Id;
        public string Title;

        public long AuthorFk;
        public long PressFk;
    }

    public struct Author
    {
        public long Id;
        public string Name;
    }

    public struct Press
    {
        public long Id;
        public string Name;
    }

    public partial class MainForm : Form
    {
        private SqlConnection _sqlConnection;
        private DataSet _dataSet;
        List<Book> _bookList = new List<Book>();
        List<Author> _authorList = new List<Author>();
        List<Press> _pressList = new List<Press>();
        private SqlDataAdapter _sqlDataAdapter;
        private string _commandSelect;
        private string _authorSearch;
        private string _pressSearch;
        private bool _canSearch = false;
        private long _indexAuthor = -1;
        private long _indexPress = -1;

        public MainForm()
        {
            string connectionString = "Data Source=(local);Initial Catalog=BooksAuthorsPresses;Integrated Security=True";
            _sqlConnection = new SqlConnection(connectionString);
            _dataSet = new DataSet("BooksAuthorsPresses");
            _sqlDataAdapter = new SqlDataAdapter();

            InitializeComponent();

            comboBoxAuthors.Enabled = false;
            comboBoxPresses.Enabled = false;

            FillComboboxAuthors();
            FillComboboxPresses();

            FillListBooks();
        }

        public void FillComboboxAuthors()
        {
            _commandSelect = "SELECT Id, Name FROM Authors";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_commandSelect, _sqlConnection);

            _dataSet.Clear();
            comboBoxAuthors.Items.Clear();
            _sqlDataAdapter.Fill(_dataSet);
            _authorList.Clear();

            _authorList = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Author
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            foreach (var author in _authorList)
            {
                comboBoxAuthors.Items.Add(author.Name);
            }
        }

        public void FillComboboxPresses()
        {
            _commandSelect = "SELECT Id, Name FROM Presses";
            _sqlDataAdapter.SelectCommand = new SqlCommand(_commandSelect, _sqlConnection);

            _dataSet.Clear();
            comboBoxPresses.Items.Clear();
            _sqlDataAdapter.Fill(_dataSet);
            _pressList.Clear();

            _pressList = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Press
            {
                Id = dataRow.Field<long>("Id"),
                Name = dataRow.Field<string>("Name")
            }).ToList();

            foreach (var press in _pressList)
            {
                comboBoxPresses.Items.Add(press.Name);
            }
        }

        private void checkBoxAuthors_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBoxAuthors.Checked)
            {
                comboBoxAuthors.Enabled = true;
            }
            else
            {
                comboBoxAuthors.Enabled = false;
                comboBoxAuthors.SelectedItem = null;
                _authorSearch = null;
            }   
        }

        private void checkBoxPresses_CheckedChanged(object sender, System.EventArgs e)
        {
            if (checkBoxPresses.Checked)
            {
                comboBoxPresses.Enabled = true;
            }
            else
            {
                comboBoxPresses.Enabled = false;
                comboBoxPresses.SelectedItem = null;
                _pressSearch = null;
            }
        }

        private void burronSearch_Click(object sender, System.EventArgs e)
        {
            //Вариант когда есть выбранный элемент
            if (comboBoxAuthors.SelectedItem != null)
            {
                _authorSearch = comboBoxAuthors.SelectedItem.ToString();

                _canSearch = true;
            }
            else
            {
                //Вариант когда комбобокс с авторами активен, 
                //автор не выбран,
                //комбобокс с издательствами не активен.
                if (comboBoxAuthors.Enabled && !comboBoxPresses.Enabled)
                {
                    MessageBox.Show("Choose author, please", "Author?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _canSearch = false;
                }

                //Вариант, когда оба комбобса не активны,
                //но кнопка искать нажата
                if (!comboBoxAuthors.Enabled && !comboBoxPresses.Enabled)
                {
                    MessageBox.Show("Choose press, author or both, please", "Press, author or both?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _canSearch = false;
                }
            }

            //Вариант, когда есть выбранный элемент
            if (comboBoxPresses.SelectedItem != null)
            {
                _pressSearch = comboBoxPresses.SelectedItem.ToString();

                _canSearch = true;
            }
            else
            {
                //Вариант когда комбобокс с издательствами активен, 
                //издательство не выбрано,
                //комбобокс с авторами не активен.
                if (comboBoxPresses.Enabled && !comboBoxAuthors.Enabled)
                {
                    MessageBox.Show("Choose author, please", "Press?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _canSearch = false;
                }

                //Вариант, когда оба комбобокса активны, но элементы не выбраны
                else if (comboBoxPresses.Enabled && comboBoxAuthors.Enabled)
                {
                    MessageBox.Show("Choose press and author, please", "Press and author?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _canSearch = false;
                }
            }

            Search();
            FillListBoxBooks();
        }

        public void Search()
        {
            if (_canSearch)
            {
                _indexAuthor = -1;
                _indexPress = -1;

                if (_authorSearch != null && _pressSearch == null)
                {
                    foreach (var author in _authorList)
                    {
                        if (_authorSearch == author.Name)
                        {
                            _indexAuthor = author.Id;
                            break;
                        }
                    }
                }

                else if (_authorSearch == null && _pressSearch != null)
                {
                    foreach (var press in _pressList)
                    {
                        if (_pressSearch == press.Name)
                        {
                            _indexPress = press.Id;
                            break;
                        }
                    }
                }

                else if (_authorSearch != null && _pressSearch != null)
                {
                    foreach (var author in _authorList)
                    {
                        if (_authorSearch == author.Name)
                        {
                            _indexAuthor = author.Id;
                            break;
                        }
                    }

                    foreach (var press in _pressList)
                    {
                        if (_pressSearch == press.Name)
                        {
                            _indexPress = press.Id;
                            break;
                        }
                    }

                }
            }
        }

        public void FillListBooks()
        {
            _commandSelect = "SELECT Books.Id, Title, AuthorFk, PressFk FROM Books, Authors, Presses" +
                             " WHERE AuthorFk=Authors.Id AND PressFk = Presses.Id";
                _sqlDataAdapter.SelectCommand = new SqlCommand(_commandSelect, _sqlConnection);

                _dataSet.Clear();
                _sqlDataAdapter.Fill(_dataSet);
                _bookList.Clear();

            _bookList = _dataSet.Tables[0].AsEnumerable().Select(dataRow =>
            new Book
            {
                Id = dataRow.Field<long>("Id"),
                Title = dataRow.Field<string>("Title"),

                AuthorFk = dataRow.Field<long>("AuthorFk"),
                PressFk = dataRow.Field<long>("PressFk")
            }).ToList();
        }

        public void FillListBoxBooks()
        {
            listBoxBooks.Items.Clear();

            if(_indexAuthor != -1 && _indexPress != -1)
            {
                SearchAuthorAndPress();
            }

            if(_indexAuthor != -1 && _indexPress == -1)
            {
                SearchAuthor();
            }

            if(_indexPress != -1 && _indexAuthor == -1)
            {
                SearchPress();
            }
        }

        public void SearchAuthorAndPress()
        {
            foreach (var book in _bookList)
            {
                if (book.AuthorFk == _indexAuthor && book.PressFk == _indexPress)
                {
                    listBoxBooks.Items.Add(book.Title);
                }
            }
        }

        public void SearchAuthor()
        {
            foreach (var book in _bookList)
            {
                if (book.AuthorFk == _indexAuthor)
                {
                    listBoxBooks.Items.Add(book.Title);
                }
            }
        }

        public void SearchPress()
        {
            foreach (var book in _bookList)
            {
                if (book.PressFk == _indexPress)
                {
                    listBoxBooks.Items.Add(book.Title);
                }
            }
        }
    }
}
