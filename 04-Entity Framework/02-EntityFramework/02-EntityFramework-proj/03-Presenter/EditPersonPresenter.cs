using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HumanResourcesDepartment._03_Presenter
{
    class EditPersonPresenter
    {
        private IViewAllInfo _viewAllInfo;
        private List<PersonInfo> _personInfos = new List<PersonInfo>();
        private ModelContext _model = ModelContext.GetModel();
        private PersonInfo _person;

        public EditPersonPresenter(IViewAllInfo viewAllInfo)
        {
            _viewAllInfo = viewAllInfo;
            _viewAllInfo.ViewAllInfoEvent += FillInfo;
            _viewAllInfo.EditedEvent += OnUpdate;
            _personInfos = _model.People.Local.ToList();
        }

        public void FillInfo(int index)
        {
            _person = _personInfos[index];

            _viewAllInfo.PersonName = _person.FirstName;
            _viewAllInfo.Surname = _person.LastName;
            _viewAllInfo.Patronymic = _person.Patronymic;
            _viewAllInfo.ContractNum = _person.ContractNumber.ToString();
            _viewAllInfo.DismissalNum = _person.DismissalNumber.ToString();
            _viewAllInfo.Birthday = _person.Birthday;

            if (!String.IsNullOrEmpty(_person.PhotoPath) && File.Exists(_person.PhotoPath))
            {
                _viewAllInfo.Path = _person.PhotoPath;
            }
        }

        public void OnUpdate()
        {
            _person.FirstName = _viewAllInfo.PersonName;
            _person.LastName = _viewAllInfo.Surname;
            _person.Patronymic = _viewAllInfo.Patronymic;
            _person.ContractNumber = int.Parse(_viewAllInfo.ContractNum);
            _person.DismissalNumber = int.Parse(_viewAllInfo.DismissalNum);
            _person.Birthday = _viewAllInfo.Birthday;
            _person.PhotoPath = _viewAllInfo.Path;

            if(_person!= null)
            _model.Edit(_person);
        }
    }
}
