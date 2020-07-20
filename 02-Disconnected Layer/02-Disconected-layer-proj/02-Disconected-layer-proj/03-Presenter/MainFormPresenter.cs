using _02_Disconected_layer_proj._01_Model;
using _02_Disconected_layer_proj._01_Model.Interfaces;
using _02_Disconected_layer_proj._02_View.Interfaces;
using System;

namespace _02_Disconected_layer_proj._03_Presenter
{
    class MainFormPresenter
    {
        private IView _view;
        private IModel _model;

        private long _indexAuthor = -1;
        private long _indexPress = -1;

        public MainFormPresenter(IView view)
        {
            _view = view;
            _model = Model.GetModel;

            _view.ViewEvent += Fill;
            _view.SearchEvent += Search;
        }

        public void Fill(object sender, EventArgs e)
        {
            _model.FillAuthorsList();
            _model.FillPressesList();
            _model.FillBooksList();

            _view.ComboBoxAuthors.Items.Clear();
            _view.ComboBoxPresses.Items.Clear();

            foreach (var author in _model.Authors)
            {
                _view.ComboBoxAuthors.Items.Add(author.Name);
            }

            foreach (var press in _model.Presses)
            {
                _view.ComboBoxPresses.Items.Add(press.Name);
            }
        }

        public void Search()
        {
            string authorSearch = String.Empty;
            string pressSearch = String.Empty;

            if (_view.ComboBoxAuthors.SelectedItem != null)
                authorSearch = _view.ComboBoxAuthors.SelectedItem.ToString();

            if (_view.ComboBoxPresses.SelectedItem != null)
                pressSearch = _view.ComboBoxPresses.SelectedItem.ToString();

            if (!String.IsNullOrEmpty(authorSearch) && String.IsNullOrEmpty(pressSearch))
            {
                foreach (var author in _model.Authors)
                {
                    if (authorSearch == author.Name)
                    {
                        _indexAuthor = author.Id;
                        break;
                    }
                }
            }
            else if (String.IsNullOrEmpty(authorSearch) && !String.IsNullOrEmpty(pressSearch))
            {
                foreach (var press in _model.Presses)
                {
                    if (pressSearch == press.Name)
                    {
                        _indexPress = press.Id;
                        break;
                    }
                }
            }
            else if (!String.IsNullOrEmpty(authorSearch) && !String.IsNullOrEmpty(pressSearch))
            {
                foreach (var author in _model.Authors)
                {
                    if (authorSearch == author.Name)
                    {
                        _indexAuthor = author.Id;
                        break;
                    }
                }

                foreach (var press in _model.Presses)
                {
                    if (pressSearch == press.Name)
                    {
                        _indexPress = press.Id;
                        break;
                    }
                }
            }
            FillListBoxBooks();
        }

        private void FillListBoxBooks()
        {
            _view.ListBoxBooks.Items.Clear();

            if (_indexAuthor != -1 && _indexPress != -1 && _view.CanSearch)
            {
                SearchAuthorAndPress();
                return;
            }

            if (_indexAuthor != -1 && _indexPress == -1 && _view.CanSearch)
            {
                SearchAuthor();
                return;
            }

            if (_indexPress != -1 && _indexAuthor == -1 && _view.CanSearch)
            {
                SearchPress();
                return;
            }

            foreach (var book in _model.Books)
            {
                _view.ListBoxBooks.Items.Add(book.Title);
            }
        }

        private void SearchAuthorAndPress()
        {
            foreach (var book in _model.Books)
            {
                if (book.AuthorFk == _indexAuthor && book.PressFk == _indexPress)
                {
                    _view.ListBoxBooks.Items.Add(book.Title);
                }
            }
        }

        private void SearchAuthor()
        {
            foreach (var book in _model.Books)
            {
                if (book.AuthorFk == _indexAuthor)
                {
                    _view.ListBoxBooks.Items.Add(book.Title);
                }
            }
        }

        private void SearchPress()
        {
            foreach (var book in _model.Books)
            {
                if (book.PressFk == _indexPress)
                {
                    _view.ListBoxBooks.Items.Add(book.Title);
                }
            }
        }
    }
}
