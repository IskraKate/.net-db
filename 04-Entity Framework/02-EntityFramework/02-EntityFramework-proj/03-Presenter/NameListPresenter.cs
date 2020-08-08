using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace HumanResourcesDepartment._03_Presenter
{
    class NameListPresenter
    {
        private IView _view;

        private List<PersonInfo> _personInfo;
        private ListView _listViewNames;

        private ModelContext _model = ModelContext.GetModel();

        public NameListPresenter(IView view)
        {
            _personInfo = new List<PersonInfo>();

            _view = view;
            _model.People.Load();

            _view.ViewEvent += OnUpdate;
            _view.DeleteEvent += Delete;
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            if (_listViewNames == null)
                _listViewNames = sender as ListView;

            _personInfo = _model.People.Local.ToList();
            FillListView();
        }

        public void Delete(int index)
        {
            _listViewNames.SelectedItems[0].Remove();
            _model.People.Remove(_personInfo[index]);
            _personInfo.RemoveAt(index);
            FillListView();
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
