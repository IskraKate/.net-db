using System.Collections.Generic;

namespace HumanResourcesDepartment.ModelNamespace
{
    interface IModel
    {
        void Connect();
        List<PersonInfo> FillList();
        void AddPersonToBase(PersonInfo personInfo);
        void EditPerson(PersonInfo personInfoEdited);
        void Delete(int index);
        void Dispose();
    }
}
