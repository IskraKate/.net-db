
using System.Collections.Generic;

namespace Sales.ModelNamespace
{
    interface IModel
    {
        void OpenConnection();
        List<Row> FillListWithElements();
    }
}
