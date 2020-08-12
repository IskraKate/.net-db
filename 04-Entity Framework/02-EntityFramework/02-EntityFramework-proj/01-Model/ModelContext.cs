using HumanResourcesDepartment._01_Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HumanResourcesDepartment.ModelNamespace
{
    public class ModelContext : DbContext
    {
        private static ModelContext _modelContext = new ModelContext();
        public DbSet<Person> People { get; set; }

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
            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id)
              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.LastName).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(p => p.LastName).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.Patronymic).HasMaxLength(50);
            modelBuilder.Entity<Person>().Property(p => p.Patronymic).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.Birthday).IsRequired();

            modelBuilder.Entity<Person>().Property(p => p.PhotoPath).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(p => p.PhotoPath).IsRequired();


            base.OnModelCreating(modelBuilder);
        }

        public void Insert(Person person)
        {
            _modelContext.People.Add(person);
            _modelContext.SaveChanges();
        }

        public void Edit(Person person)
        {
            if (person != null)
            {
                _modelContext.Entry(person).State = EntityState.Modified;
                _modelContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            _modelContext.Entry(_modelContext.People.Where(p => p.Id == id).Single()).State = EntityState.Deleted;
            _modelContext.SaveChanges();
        }
    }
}
