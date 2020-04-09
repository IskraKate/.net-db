using System;

namespace HumanResourcesDepartment.ModelNamespace
{
    public class PersonInfo
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int ContractNumber { get; set; }
        public int DismissalNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string PhotoPath { get; set; }
    }
}
