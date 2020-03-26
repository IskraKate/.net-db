using System.Collections.Generic;
using Sales.Model;
using Sales.View;

namespace Sales.PresenterNamespace
{
    class Presenter
    {
        private ConnectionWithDb _connectionWithDb;
        private List<Row> _rows = new List<Row>();
        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _connectionWithDb = new ConnectionWithDb();
            _connectionWithDb.OpenConnection();
            _rows = _connectionWithDb.FillListWithElements();
            FillListView();
        }

        public void FillListView()
        {
            foreach (var row in _rows)
            {
                _view.NewListViewItem();
                _view.GetListViewItem.Text = row.BFirstName;
                _view.GetListViewItem.SubItems.Add(row.BLastName);
                _view.GetListViewItem.SubItems.Add(row.SFirstName);
                _view.GetListViewItem.SubItems.Add(row.SLastName);
                _view.GetListViewItem.SubItems.Add(row.MoneySum);
                _view.GetListViewItem.SubItems.Add(row.Date);
            }
        }
    }
}
