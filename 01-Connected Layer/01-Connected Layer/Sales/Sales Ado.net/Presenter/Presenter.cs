using System.Windows.Forms;
using Sales.Model;

namespace Sales.PresenterNamespace
{
    class Presenter
    {
        private ListView _listView = new ListView();
        private ConnectionWithDb _connectionWithDb;
        private MainForm _mainForm;

        public MainForm MyMainForm
        {
            get
            {
                return _mainForm;
            }
        }

        public Presenter()
        {
            _connectionWithDb = new ConnectionWithDb();
            _connectionWithDb.OpenConnection();
            _listView = _connectionWithDb.FillListWithElements();
            _mainForm = new MainForm(_listView);
            if (_mainForm.IsClosed)
            {
                _connectionWithDb.CloseConnection();
            }
        }
    }
}
