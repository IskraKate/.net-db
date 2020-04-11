using System;
using System.Collections.Generic;

namespace _02_Disconected_layer_proj._02_View.Interfaces
{
    interface IView
    {
        event EventHandler ViewEvent;

        List<Author> Authors { get; set; }
        List<Book> Books { get; set; }
        List<Press> Presses { get; set; }
    }
}
