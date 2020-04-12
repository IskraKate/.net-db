using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Disconnected_layer_proj._02_View
{
    interface IView
    {
        event EventHandler ViewEvent;

        List<Check> CheckList { get; set; }
        Check check { get; }
    }
}
