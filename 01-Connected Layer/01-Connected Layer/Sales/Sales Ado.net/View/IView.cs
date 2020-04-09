using System.Windows.Forms;

namespace Sales.View
{
    interface IView
    {
        event FormClosedEventHandler FormClosed;
        ListViewItem GetListViewItem { get; }
        void NewListViewItem();
    }
}
