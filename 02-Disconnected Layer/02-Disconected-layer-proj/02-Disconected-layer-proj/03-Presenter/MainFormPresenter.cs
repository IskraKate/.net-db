using _02_Disconected_layer_proj._01_Model.Interfaces;
using _02_Disconected_layer_proj._02_View.Interfaces;
using System;

namespace _02_Disconected_layer_proj._03_Presenter
{
    class MainFormPresenter
    {
       private IView _view;
       private IModel _model;

        public MainFormPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;

            _view.ViewEvent += Fill;
        }

        public void Fill(object sender, EventArgs e)
        {
            _view.Authors = _model.FillAuthorsList(_view.Authors);
            _view.Presses = _model.FillPressesList(_view.Presses);
            _view.Books = _model.FillBooksList(_view.Books);
        }
    }
}
