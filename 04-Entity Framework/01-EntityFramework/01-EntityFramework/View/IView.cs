using System.Windows.Forms;

namespace View
{
    public delegate void ViewHandler(ListView listview);
    interface IView
    {
        event ViewHandler ViewEvent;
    }
}
