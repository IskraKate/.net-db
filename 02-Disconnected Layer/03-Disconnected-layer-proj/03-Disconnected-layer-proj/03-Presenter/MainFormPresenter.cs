using _03_Disconnected_layer_proj._01_Model.Interfaces;
using _03_Disconnected_layer_proj._02_View.Interfaces;
using _03_Disconnected_layer_proj._01_Model;
using _03_Disconnected_layer_proj._02_View;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._03_Presenter
{
    class MainFormPresenter
    {
        private IModel _model;
        private IView _view;
        private IDelete _delete;
        private ISave _save;

        public MainFormPresenter(IView view)
        {
            _view = view;
            _model = Model.GetModel;
            _delete = (IDelete)view;
            _save = (ISave)view;
            _view.ViewEvent += Fill;
            _delete.DeleteEvent += Delete;
            _save.SaveEvent += Save;
        }

        private void Fill(ListView listViewCheck)
        {
             _model.Fill();

            foreach (var check in _model.Checks)
            {
                ListViewItem item = listViewCheck.Items.Add(new ListViewItem());
                item.Text = check.Number.ToString();
                item.SubItems.Add(check.Date.ToShortDateString());
                item.SubItems.Add(check.Fridge.Brand);
                item.SubItems.Add(check.Buyer.Name);
                item.SubItems.Add(check.Seller.Name);
            }
        }

        private void Delete(int index)
        {
            _model.Delete(_model.Checks[index]);
            _model.Checks.RemoveAt(index);
        }

        private void Save()
        {
            _model.SaveToXML(_model.Checks);
        }
    }
}
