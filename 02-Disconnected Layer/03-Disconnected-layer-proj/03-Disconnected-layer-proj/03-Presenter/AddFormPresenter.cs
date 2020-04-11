using _03_Disconnected_layer_proj._02_View;
using _03_Disconnected_layer_proj.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Disconnected_layer_proj._03_Presenter
{
    class AddFormPresenter
    {
        private IModel _model;
        private IView _view;

        public AddFormPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
        }

    }
}
