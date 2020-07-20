using System;
using System.Windows.Forms;

namespace _02_Disconected_layer_proj._02_View.Interfaces
{
    public delegate void SearchHandler();
    interface IView
    {
        event EventHandler ViewEvent;
        event SearchHandler SearchEvent;

        ComboBox ComboBoxAuthors { get; set; }
        ComboBox ComboBoxPresses { get; set; }
        ListBox ListBoxBooks { get; set; }
        bool CanSearch { get; set; }
    }
}
