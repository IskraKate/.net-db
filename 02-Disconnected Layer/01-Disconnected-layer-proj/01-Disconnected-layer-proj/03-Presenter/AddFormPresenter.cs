using _01_Disconnected_layer_proj._01_Model;
using _01_Disconnected_layer_proj._02_View;
using System;
using System.Linq;

namespace _01_Disconnected_layer_proj._03_Presenter
{
    class AddFormPresenter
    {
        private IView _view;
        private IModel _model;

        public AddFormPresenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _view.ViewEvent += AddToBase;
        }

        public void AddToBase(object sender, EventArgs e)
        {
            _model.Add(_view.UserList.Last());
        }
    }
}
