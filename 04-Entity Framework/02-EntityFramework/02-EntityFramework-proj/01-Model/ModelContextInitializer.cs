using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Data.Entity;

namespace HumanResourcesDepartment._01_Model
{
    class ModelContextInitializer : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {

            var people = new PersonInfo[]
            {
                new PersonInfo {Id = 1, FirstName = "FirstPersonName", LastName = "FirstPersonSurname",
                                Patronymic="FirstPersonPatronymic", Birthday = new DateTime(1994,04,08),
                                ContractNumber = 1234567, DismissalNumber = 1234567, PhotoPath=@"D:\05-Photos\COFFEE\coffee1.jpg"},
                new PersonInfo {Id = 2, FirstName = "LastPersonName", LastName = "LastPersonSurname",
                                Patronymic="LastPersonPatronymic", Birthday = new DateTime(1994,04,09),
                                ContractNumber = 1234567, DismissalNumber = 1234567, PhotoPath=@"D:\05-Photos\COFFEE\coffee2.jpg"}

            };

            foreach (var person in people)
                context.People.Add(person);

            base.Seed(context);
        }
    }
}
