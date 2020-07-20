using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HumanResourcesDepartment._03_Presenter
{
    class NameListPresenter
    {
        private IView _view;
        private IModel _model;
        private IDispose _dispose;

        private List<PersonInfo> _personInfo;
        private ListView _listViewNames;

        public NameListPresenter(IView view)
        {
            _personInfo = new List<PersonInfo>();

            _view = view;
            _model = Model.GetModel();
            _dispose = (IDispose)view;

            _model.Connect();

            _view.ViewEvent += OnUpdate;
            _dispose.FormClosedEvent += Dispose;
            _view.DeleteEvent += Delete;
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            if (_listViewNames == null)
                _listViewNames = sender as ListView;

            _personInfo = _model.FillList();
            FillListView();
        }

        public void Delete(int index)
        {
            _listViewNames.SelectedItems[0].Remove();
            _model.Delete(index);
            FillListView();
        }

        public void Dispose(object sender, FormClosedEventArgs e)
        {
            _model.Dispose();
        }

        public void FillListView()
        {
            if (_listViewNames != null)
            {
                _listViewNames.Items.Clear();

                foreach (var info in _personInfo)
                {
                    ListViewItem listViewItem = _listViewNames.Items.Add(new ListViewItem());
                    listViewItem.Text = info.FirstName + ' ' + info.LastName + ' ' + info.Patronymic;
                }
            }
        }
    }
}
