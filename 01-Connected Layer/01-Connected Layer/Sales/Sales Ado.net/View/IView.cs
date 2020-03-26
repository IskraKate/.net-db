using System.Windows.Forms;
using Sales;

namespace Sales.View
{
    interface IView
    {
        ListView GetListView { get; }
        ListViewItem GetListViewItem { get; }
        void NewListViewItem();
    }
}
