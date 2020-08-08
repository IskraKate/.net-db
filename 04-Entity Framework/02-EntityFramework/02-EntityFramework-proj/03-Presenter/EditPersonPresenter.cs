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
        int _index;
        private IViewAllInfo _viewAllInfo;
        private List<PersonInfo> _personInfos = new List<PersonInfo>();
        private ModelContext _model = ModelContext.GetModel();

        public EditPersonPresenter(IViewAllInfo viewAllInfo)
        {
            _viewAllInfo = viewAllInfo;
            _viewAllInfo.ViewAllInfoEvent += FillInfo;
            _viewAllInfo.EditedEvent += OnUpdate;
            _personInfos = _model.People.Local.ToList();
        }

        public void FillInfo(int index)
        {
            _index = index;

            _viewAllInfo.PersonName = _personInfos[_index].FirstName;
            _viewAllInfo.Surname = _personInfos[_index].LastName;
            _viewAllInfo.Patronymic = _personInfos[_index].Patronymic;
            _viewAllInfo.ContractNum = _personInfos[_index].ContractNumber.ToString();
            _viewAllInfo.DismissalNum = _personInfos[_index].DismissalNumber.ToString();
            _viewAllInfo.Birthday = _personInfos[_index].Birthday;

            if (!String.IsNullOrEmpty(_personInfos[_index].PhotoPath) && File.Exists(_personInfos[_index].PhotoPath))
            {
                _viewAllInfo.Path = _personInfos[_index].PhotoPath;
            }
        }

        public void OnUpdate()
        {
            var personInfo = new PersonInfo()
            {
                FirstName = _viewAllInfo.PersonName,
                LastName = _viewAllInfo.Surname,
                Patronymic = _viewAllInfo.Patronymic,
                ContractNumber = int.Parse( _viewAllInfo.ContractNum),
                DismissalNumber = int.Parse(_viewAllInfo.DismissalNum),
                Birthday = _viewAllInfo.Birthday,
                PhotoPath = _viewAllInfo.Path
            };

            _model.Edit(personInfo, _index);
        }
    }
}
