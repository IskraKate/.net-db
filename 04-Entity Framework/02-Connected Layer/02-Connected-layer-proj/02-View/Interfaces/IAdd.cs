using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumanResourcesDepartment._02_View.Interfaces
{
    public delegate void AddHandler();
    interface IAdd
    {
        string AddName { get; }
        string AddSurname { get; }
        string AddPatronymic { get; }
        int AddContractNum { get; }
        int AddDismissalNum { get; }
        DateTime AddBirthday { get; }
        string AddPhoto { get; }

        event AddHandler AddEvent;
    }
}
