using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System.Collections.Generic;

namespace HumanResourcesDepartment.PresenterNamespace
{
    class Presenter
    {
        private IView _view;
        private IModel _model;
        private List<PersonInfo> _personInfos = new List<PersonInfo>();

        public Presenter(IView view, IModel model)
        {
            _view = view;
            _model = model;
            _model.Connect();
            _model.FillList();
            _personInfos = _model.GetInfos();
            FillListView();
            _view.AddEvent += AddPerson;
            _view.GetPersonEvent += GetPerson;
            _view.EditEvent += EditPerson;
            _view.DeleteEvent += DeletePerson;
            _view.FormClosingEvent += _view_FormClosing; 
        }

        public void AddPerson(PersonInfo personInfo)
        {
            _personInfos.Add(personInfo);
            _view.NewListViewItem();
            _view.GetListViewItem.Text = personInfo.FirstName + ' ' + personInfo.LastName;
            _model.AddPersonToBase(personInfo);
        }

        public void EditPerson(PersonInfo personInfoEdited)
        {
            for (int i = 0; i < _personInfos.Count; i++)
            {
                if (_personInfos[i].Id == personInfoEdited.Id)
                {
                    _personInfos[i] = personInfoEdited;
                    _view.GetListView.SelectedItems[0].Text = _personInfos[i].FirstName + ' ' 
                        + _personInfos[i].LastName + ' ' + _personInfos[i].Patronymic;
                    _model.EditPerson(_personInfos[i]);
                    break;
                }
            }
         
        }

        public void DeletePerson(int index)
        {
            _model.Delete(index);
            _personInfos.RemoveAt(index);
            _view.GetListView.Items[index].Remove();
        }

        public PersonInfo GetPerson(int index)
        {
            return _personInfos[index];
        }

        public void FillListView()
        {
            foreach (var info in _personInfos)
            {
                _view.NewListViewItem();
                _view.GetListViewItem.Text = info.FirstName + ' ' + info.LastName;
            }
        }

        private void _view_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _model.CloseConnection();
        }

    }
}
