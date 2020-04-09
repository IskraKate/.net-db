using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Collections.Generic;

namespace HumanResourcesDepartment.View
{
    interface IView
    {
        event EventHandler ViewEvent;

        List<PersonInfo> PersonInfo { get; set; }

    }
}
