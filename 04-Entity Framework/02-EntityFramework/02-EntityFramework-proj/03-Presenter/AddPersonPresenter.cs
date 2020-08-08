using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment._02_View.Interfaces;
using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System.Windows.Forms;

namespace HumanResourcesDepartment._03_Presenter
{
    class AddPersonPresenter
    {
        IModel _model;
        IAdd _view;

        public AddPersonPresenter(IAdd view)
        {
            _view = view;
            _view.AddEvent += AddPersonModel;
        }

        public void AddPersonModel()
        {
            PersonInfo personInfo= new PersonInfo
            {
                FirstName = _view.AddName,
                LastName = _view.AddSurname,
                Patronymic = _view.AddPatronymic,
                Birthday = _view.AddBirthday,
                ContractNumber = _view.AddContractNum,
                DismissalNumber = _view.AddDismissalNum,
                PhotoPath = _view.AddPhoto
            };

           //_model.AddPersonToBase(personInfo);
        }
    }
}
