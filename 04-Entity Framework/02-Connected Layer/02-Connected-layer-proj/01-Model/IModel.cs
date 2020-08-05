using System.Collections.Generic;

namespace HumanResourcesDepartment.ModelNamespace
{
    interface IModel
    {
        void Connect();
        List<PersonInfo> FillList();
        List<PersonInfo> GetInfo();
        void AddPersonToBase(PersonInfo personInfo);
        void EditPerson(List<PersonInfo> personInfoEdited, int index);
        void Delete(int index);
        void Dispose();
    }
}
