using System;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj._02_View
{
    interface IView
    {
        event EventHandler ViewEvent;

        string Login { get; set; }

        bool IsChecked { get; set; }

        bool IsAdmin { get; set; }

        ListBox ListBox { get; set; }

    }
}
