using System;

namespace HumanResourcesDepartment.View
{
    public delegate void DeleteHandler(int index);
    interface IView
    {
        event EventHandler ViewEvent;
        event DeleteHandler DeleteEvent;
    }
}
