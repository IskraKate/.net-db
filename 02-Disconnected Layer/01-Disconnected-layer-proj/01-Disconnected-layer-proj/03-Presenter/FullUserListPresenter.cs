using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
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

        public FullUserListPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
        }
    }
}
