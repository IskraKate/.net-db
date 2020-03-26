using System;
using System.Windows.Forms;
using Sales;

namespace Sales.View
{
    interface IView
    {
        event FormClosedEventHandler FormClosed;
        ListView GetListView { get; }
        ListViewItem GetListViewItem { get; }
        void NewListViewItem();
    }
}
