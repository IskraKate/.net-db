using System;
using System.Windows.Forms;

namespace _03_Disconnected_layer_proj._02_View
{
    public delegate void ViewHandler(ListView checklist);
    interface IView
    {
        event ViewHandler ViewEvent;
    }
}
