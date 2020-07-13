using HumanResourcesDepartment._02_View.Interfaces;
using HumanResourcesDepartment.ModelNamespace;
using System;

namespace HumanResourcesDepartment._03_Presenter
{
    class AddPersonPresenter
    {
        IModel _model;
        IAdd _add;

        public AddPersonPresenter(IAdd add, IModel model)
        {
            _add = add;
            _model = model;
            _add.AddEvent += AddPersonModel;
        }

        public void AddPersonModel(string name, string surname, string patronymic,
         int contractNum, int DismissalNum, DateTime birthday, string path)
        {
            PersonInfo personInfo= new PersonInfo
            {
                FirstName = name,
                LastName = surname,
                Patronymic = patronymic,
                Birthday = birthday,
                ContractNumber = contractNum,
                DismissalNumber = DismissalNum,
                PhotoPath = path
            };

            _model.AddPersonToBase(personInfo);
        }
    }
}
