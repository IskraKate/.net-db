using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Elements
{
    class Buyer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }


        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        public ICollection<Sales> Sales { get; set; }
    }
}
