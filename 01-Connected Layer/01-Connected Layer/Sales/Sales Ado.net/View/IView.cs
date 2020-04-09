using System;
using System.Collections.Generic;

namespace Sales.View
{
    interface IView
    {
        List<Row> Rows { get; set; }

        event EventHandler ViewEvent;

    }
}
