using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class UserListFormPresenter
    {
       private IView _view;
       private IModel _model;

        public UserListFormPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ViewEvent += FillListFromBase;
        }

        public void FillListFromBase(object sender, EventArgs e)
        {
            _view.UserList = _model.FillList(_view.UserList);
        }
    }
}
