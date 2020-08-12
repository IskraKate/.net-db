using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanResourcesDepartment.ModelNamespace
{
    public class Person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Patronymic { get; set; }

        [Required]
        public int ContractNumber { get; set; }

        [Required]
        public int DismissalNumber { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime Birthday { get; set; }

        [MaxLength(100)]
        [Required]
        public string PhotoPath { get; set; }
    }
}
