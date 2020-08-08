using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Model.Elements
{
    class Sales
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? SellerFk { get; set; }
        [ForeignKey("SellerFk")]
        public virtual Seller Seller { get; set; }

        public long? BuyerFk { get; set; }
        [ForeignKey("BuyerFk")]
        public virtual Buyer Buyer { get; set; }

        public int? MoneySum { get; set; }

        public DateTime Date { get; set; }
    }
}
