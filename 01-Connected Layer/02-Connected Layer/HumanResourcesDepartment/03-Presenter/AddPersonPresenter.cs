using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Linq;

namespace HumanResourcesDepartment._03_Presenter
{
    class AddPersonPresenter
    {
        IModel _model;
        IView _view;

        public AddPersonPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ViewEvent += AddPersonModel;
        }

        public void AddPersonModel(object sender, EventArgs e)
        {
            _model.AddPersonToBase(_view.PersonInfo.Last());
        }
    }
}
