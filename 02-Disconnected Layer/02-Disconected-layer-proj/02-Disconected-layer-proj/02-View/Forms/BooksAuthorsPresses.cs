using _02_Disconected_layer_proj._02_View.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _02_Disconected_layer_proj
{
    public partial class MainForm : Form, IView
    {
        public List<Book> Books { get; set; }
        public List<Author> Authors { get; set; }
        public List<Press> Presses { get; set; }

        private string _authorSearch;
        private string _pressSearch;
        private bool _canSearch = false;

        private long _indexAuthor = -1;
        private long _indexPress = -1;

        public event EventHandler ViewEvent;

        public MainForm()
        {
            InitializeComponent();

            comboBoxAuthors.Enabled = false;
            comboBoxPresses.Enabled = false;

            Books = new List<Book>();
            Authors = new List<Author>();
            Presses = new List<Press>();
        }

        private void FillComboboxAuthors()
        {
            comboBoxAuthors.Items.Clear();

            foreach (var author in Authors)
            {
                comboBoxAuthors.Items.Add(author.Name);
            }
        }

        private void FillComboboxPresses()
        {
            comboBoxPresses.Items.Clear();
            foreach (var press in Presses)
            {
                comboBoxPresses.Items.Add(press.Name);
            }
        }

        private void CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            ComboBox comboBox = checkBox.Parent.Controls[0] as ComboBox;

            if (checkBox.Checked)
            {
                comboBox.Enabled = true;
            }
            else
            {
                comboBox.Enabled = false;
                comboBox.SelectedItem = null;

                _authorSearch = null;
                _pressSearch = null;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
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

        private void Search()
        {
            if (_canSearch)
            {
                _indexAuthor = -1;
                _indexPress = -1;

                if (_authorSearch != null && _pressSearch == null)
                {
                    foreach (var author in Authors)
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
                    foreach (var press in Presses)
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
                    foreach (var author in Authors)
                    {
                        if (_authorSearch == author.Name)
                        {
                            _indexAuthor = author.Id;
                            break;
                        }
                    }

                    foreach (var press in Presses)
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

        private void FillListBoxBooks()
        {
            listBoxBooks.Items.Clear();

            if (_indexAuthor != -1 && _indexPress != -1 && _canSearch)
            {
                SearchAuthorAndPress();
                return;
            }

            if (_indexAuthor != -1 && _indexPress == -1 && _canSearch)
            {
                SearchAuthor();
                return;
            }

            if (_indexPress != -1 && _indexAuthor == -1 && _canSearch)
            {
                SearchPress();
                return;
            }

            foreach (var book in Books)
            {
                listBoxBooks.Items.Add(book.Title);
            }
        }

        private void SearchAuthorAndPress()
        {
            foreach (var book in Books)
            {
                if (book.AuthorFk == _indexAuthor && book.PressFk == _indexPress)
                {
                    listBoxBooks.Items.Add(book.Title);
                }
            }
        }

        private void SearchAuthor()
        {
            foreach (var book in Books)
            {
                if (book.AuthorFk == _indexAuthor)
                {
                    listBoxBooks.Items.Add(book.Title);
                }
            }
        }

        private void SearchPress()
        {
            foreach (var book in Books)
            {
                if (book.PressFk == _indexPress)
                {
                    listBoxBooks.Items.Add(book.Title);
                }
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillComboboxAuthors();
            FillComboboxPresses();
        }

    }
}
