using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Disconnected_layer_proj._02_View.Interfaces
{
    interface IValidate
    {
        bool ValidEmailAddress(string emailAddress, out string errorMessage);
        bool ValidLogin(string login, out string errorMessage);
        bool ValidPassword(string password, out string errorMessage);
        bool ValidTelephoneNumber(string number, out string errorMessage);
   }
}
