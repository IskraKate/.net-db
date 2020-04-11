using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using _03_Disconnected_layer_proj.Model;
using System;

namespace _03_Disconnected_layer_proj._03_Presenter
{
    class MainFormPresenter
    {
        private IModel _model;
        private IView _view;
        private IDelete _delete;
        private ISave _save;

        public MainFormPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _delete = (IDelete)view;
            _save = (ISave)view;
            _view.ViewEvent += Fill;
            _delete.DeleteEvent += Delete;
            _save.SaveEvent += Save;
        }

        private void Fill(object sender, EventArgs e)
        {
            _view.CheckList = _model.Fill(_view.CheckList);
        }

        private void Delete(object sender, EventArgs e)
        {
            _model.Delete(_view.check);
        }

        private void Save(object sender, EventArgs e)
        {
            _model.SaveToXML(_view.CheckList);
        }
    }
}
