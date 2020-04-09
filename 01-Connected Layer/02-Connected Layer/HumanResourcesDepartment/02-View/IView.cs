using HumanResourcesDepartment.ModelNamespace;
using System.Windows.Forms;

namespace HumanResourcesDepartment.View
{
    public delegate void AddHandler(PersonInfo personInfo);
    public delegate void EditHandler(PersonInfo personInfoEdited);
    public delegate PersonInfo GetPersonHandler(int index);
    public delegate void DeleteHandler(int index);

    interface IView
    {
        event AddHandler AddEvent;
        event EditHandler EditEvent;
        event GetPersonHandler GetPersonEvent;
        event DeleteHandler DeleteEvent;
        event FormClosingEventHandler FormClosingEvent;
        ListViewItem GetListViewItem { get; }
        ListView GetListView { get; }
        void NewListViewItem();
    }
}
