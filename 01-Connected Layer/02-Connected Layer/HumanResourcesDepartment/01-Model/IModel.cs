using System.Collections.Generic;

namespace HumanResourcesDepartment.ModelNamespace
{
    interface IModel
    {
        List<PersonInfo> GetInfos();
        void Connect();
        void FillList();
        void CloseConnection();
        void AddPersonToBase(PersonInfo personInfo);
        void EditPerson(PersonInfo personInfoEdited);
        void Delete(int index);
    }
}
