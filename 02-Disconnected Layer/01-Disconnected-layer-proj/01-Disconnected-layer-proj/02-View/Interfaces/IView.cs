using System;
using System.Collections.Generic;

namespace _01_Disconnected_layer_proj._02_View
{
    interface IView
    {
        event EventHandler ViewEvent;

         List<User> UserList { get; set; }

    }
}
