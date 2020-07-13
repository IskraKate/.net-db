using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Collections.Generic;

namespace HumanResourcesDepartment.View
{
    public delegate void DeleteHandler(int index);
    interface IView
    {
        event EventHandler ViewEvent;
        event DeleteHandler DeleteEvent;
    }
}
