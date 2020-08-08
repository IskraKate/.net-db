using HumanResourcesDepartment._01_Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HumanResourcesDepartment.ModelNamespace
{
    public class ModelContext : DbContext
    {
        private static ModelContext _modelContext = new ModelContext();
        public DbSet<PersonInfo> People { get; set; }

        private ModelContext() : base("PeopleEntity")
        {
            Database.SetInitializer(new ModelContextInitializer());
        }

        static public ModelContext GetModel()
        {
            return _modelContext;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInfo>().HasKey(p => p.Id);
            modelBuilder.Entity<PersonInfo>().Property(p => p.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PersonInfo>().Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Entity<PersonInfo>().Property(p => p.FirstName).IsRequired();

            modelBuilder.Entity<PersonInfo>().Property(p => p.LastName).HasMaxLength(50);
            modelBuilder.Entity<PersonInfo>().Property(p => p.LastName).IsRequired();

            modelBuilder.Entity<PersonInfo>().Property(p => p.Patronymic).HasMaxLength(50);
            modelBuilder.Entity<PersonInfo>().Property(p => p.Patronymic).IsRequired();

            modelBuilder.Entity<PersonInfo>().Property(p => p.PhotoPath).HasMaxLength(100);
            modelBuilder.Entity<PersonInfo>().Property(p => p.PhotoPath).IsRequired();

            modelBuilder.Entity<PersonInfo>().Property(p => p.Birthday).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        public void Insert(PersonInfo person)
        {
            People.Add(person);
        }

        public void Edit(PersonInfo person, int index)
        {
            var editPerson = People.FirstOrDefault(a => a.Id == index);
            if (editPerson != null)
            {
                _modelContext.Entry(editPerson).State = EntityState.Modified;
            }
        }
    }
}
