using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment._03_Presenter
{
    class NameListPresenter
    {
        private IView _view;
        private IModel _model;
        private IDelete _delete;
        private IDispose _dispose;

        public NameListPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _delete = (IDelete)view;
            _dispose = (IDispose)view;

            _model.Connect();

            _view.ViewEvent += OnUpdate;
            _dispose.FormClosedEvent += Dispose;
            _delete.DeleteEvent += Delete;
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            _view.PersonInfo = _model.FillList();
        }

        public void Delete(int index)
        {
            _model.Delete(index);
        }

        public void Dispose(object sender, FormClosedEventArgs e)
        {
            _model.Dispose();
        }
    }
}
