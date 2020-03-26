using System.Windows.Forms;
using Sales;

namespace Sales.View
{
    interface IView
    {
        FormClosedEventHandler ClosedEventHandler { get; }
        ListView GetListView { get; }
        ListViewItem GetListViewItem { get; }
        void NewListViewItem();
    }
}
