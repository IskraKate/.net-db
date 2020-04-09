using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;

namespace HumanResourcesDepartment._03_Presenter
{
    class EditPersonPresenter
    {
       private IView _view;
       private IModel _model;

        public EditPersonPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ViewEvent += EditPersonInBase;
        }

        public void EditPersonInBase(object sender, EventArgs e)
        {
            FormAllInfo tempForm = sender as FormAllInfo;
            _model.EditPerson(tempForm.CurrentPerson);
        }
    }
}
