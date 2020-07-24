using System;

namespace _03_Disconnected_layer_proj._02_View.Interfaces
{
    public delegate void DeleteHandler(int index);
    interface IDelete
    {
        event DeleteHandler DeleteEvent;
    }
}
