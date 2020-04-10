using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using _01_Disconnected_layer_proj._02_View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class FullUserListPresenter
    {
       private IView _view;
       private IModel _model;
       private IDelete _delete;

        public FullUserListPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _delete = (IDelete)view;
            _view.ViewEvent += EditListInBase;
            _delete.DeleteEvent += DeleteInBase;
        }

        public void EditListInBase(object sender, EventArgs e)
        {
             FullUserInfoForm tempForm = sender as FullUserInfoForm;
            _model.Edit(tempForm.CurrentPerson);
        }

        public void DeleteInBase(object sender, EventArgs e)
        {
            FullUserInfoForm tempForm = sender as FullUserInfoForm;
            _model.Delete(tempForm.CurrentPerson);
        }
    }
}
