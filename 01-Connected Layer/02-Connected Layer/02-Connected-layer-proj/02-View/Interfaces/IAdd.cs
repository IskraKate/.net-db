using System;

namespace HumanResourcesDepartment._02_View.Interfaces
{
    public delegate void AddHandler(string name, string surname, string patronymic,
         int contractNum, int DismissalNum, DateTime birthday, string path);
    public interface IAdd
    {
        event AddHandler AddEvent;
    }
}
