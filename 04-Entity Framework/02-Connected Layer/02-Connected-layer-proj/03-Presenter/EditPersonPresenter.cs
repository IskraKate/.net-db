using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Collections.Generic;
using System.IO;

namespace HumanResourcesDepartment._03_Presenter
{
    class EditPersonPresenter
    {
       int _index;
       private IViewAllInfo _viewAllInfo;
       private IModel _model;
       private List<PersonInfo> _infos;

        public EditPersonPresenter(IViewAllInfo viewAllInfo)
        {
            _viewAllInfo = viewAllInfo;
            _model = Model.GetModel();
            _viewAllInfo.ViewAllInfoEvent += FillInfo;
            _viewAllInfo.EditedEvent += OnUpdate;
            _infos = _model.GetInfo();
        }

        public void FillInfo(int index)
        {
            _index = index;

            _viewAllInfo.PersonName = _infos[_index].FirstName;
            _viewAllInfo.Surname = _infos[_index].LastName;
            _viewAllInfo.Patronymic = _infos[_index].Patronymic;
            _viewAllInfo.ContractNum = _infos[_index].ContractNumber.ToString();
            _viewAllInfo.DismissalNum = _infos[_index].DismissalNumber.ToString();
            _viewAllInfo.Birthday = _infos[_index].Birthday;

            if (!String.IsNullOrEmpty(_infos[_index].PhotoPath) && File.Exists(_infos[_index].PhotoPath))
            {
                _viewAllInfo.Path =  _infos[_index].PhotoPath;
            }
        }

        public void OnUpdate()
        {
            _infos[_index].FirstName = _viewAllInfo.PersonName;
            _infos[_index].LastName = _viewAllInfo.Surname;
            _infos[_index].Patronymic = _viewAllInfo.Patronymic;
            _infos[_index].ContractNumber = int.Parse(_viewAllInfo.ContractNum);
            _infos[_index].DismissalNumber = int.Parse(_viewAllInfo.DismissalNum);
            _infos[_index].Birthday = _viewAllInfo.Birthday;

            if (!String.IsNullOrEmpty(_viewAllInfo.Path))
            _infos[_index].PhotoPath = _viewAllInfo.Path;

            _model.EditPerson(_infos, _index);
        }
    }
}
