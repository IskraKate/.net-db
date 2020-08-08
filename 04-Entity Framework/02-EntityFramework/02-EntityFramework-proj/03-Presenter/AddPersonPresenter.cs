using HumanResourcesDepartment._02_View.Interfaces;
using HumanResourcesDepartment.ModelNamespace;

namespace HumanResourcesDepartment._03_Presenter
{
    class AddPersonPresenter
    {
        private IAdd _view;
        private ModelContext _model = ModelContext.GetModel();

        public AddPersonPresenter(IAdd view)
        {
            _view = view;
            _view.AddEvent += AddPersonModel;
        }

        public void AddPersonModel()
        {
            PersonInfo personInfo = new PersonInfo
            {
                FirstName = _view.AddName,
                LastName = _view.AddSurname,
                Patronymic = _view.AddPatronymic,
                Birthday = _view.AddBirthday,
                ContractNumber = _view.AddContractNum,
                DismissalNumber = _view.AddDismissalNum,
                PhotoPath = _view.AddPhoto
            };

           _model.Insert(personInfo);
        }
    }
}
