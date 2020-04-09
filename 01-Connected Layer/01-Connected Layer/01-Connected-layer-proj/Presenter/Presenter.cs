using System;
using System.Collections.Generic;
using Sales.ModelNamespace;
using Sales.View;
namespace Sales.PresenterNamespace
{
    class Presenter
    {
        private List<Row> _rows = new List<Row>();
        private IView _view;
        private IModel _model;

        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _model.OpenConnection();
            _view.ViewEvent += OnUpdate;
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            _view.Rows = _model.FillListWithElements();
        }

    }
}
