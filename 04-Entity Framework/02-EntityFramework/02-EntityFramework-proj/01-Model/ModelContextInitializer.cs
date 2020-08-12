using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Data.Entity;

namespace HumanResourcesDepartment._01_Model
{
    class ModelContextInitializer : CreateDatabaseIfNotExists<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {

            var people = new Person[]
            {
                new Person {Id = 1, FirstName = "Kate", LastName = "Iskra",
                                Patronymic="Hennadievna",
                                ContractNumber = 1567, DismissalNumber = 1267, Birthday = new DateTime(1994,04,08),
                                PhotoPath=@"D:\05-Photos\COFFEE\coffee1.jpg"},

                new Person {Id = 2, FirstName = "Kirill", LastName = "Krasnov",
                                Patronymic="Denisovych",
                                ContractNumber = 1267, DismissalNumber = 1267, Birthday = new DateTime(1994,04,09),
                                PhotoPath=@"D:\05-Photos\COFFEE\coffee2.jpg"}

            };

            Array.ForEach(people, person => context.People.Add(person));

            base.Seed(context);
        }
    }
}
