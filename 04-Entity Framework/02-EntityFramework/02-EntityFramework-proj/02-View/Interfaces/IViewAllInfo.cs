using System;

namespace HumanResourcesDepartment._02_View
{
    public delegate void ViewAllInfoHandler(int index);

    public delegate void EditedHandler();

    public interface IViewAllInfo
    {
        string PersonName { get; set; }
        string Surname { get; set; }
        string Patronymic { get; set; }
        string ContractNum { get; set; }
        string DismissalNum { get; set; }
        DateTime Birthday { get; set; }
        string Path { get; set; }

        event ViewAllInfoHandler ViewAllInfoEvent;
        event EditedHandler EditedEvent;
    }
}
