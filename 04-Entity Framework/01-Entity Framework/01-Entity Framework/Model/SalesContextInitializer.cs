using Model.Elements;
using ModelNamespace;
using System.Data.Entity;

namespace SalesNamespace.Model
{
    class SalesContextInitializer : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            var sellers = new Seller[]
            {
                new Seller { Id = 1, FirstName = "FirstSeller" , LastName = "FirstSellerL" },
                new Seller { Id = 2, FirstName = "SecondSeller", LastName = "SecondSellerL"},
                new Seller { Id = 3, FirstName = "ThirdSeller" , LastName = "ThirdSellerL" },
                new Seller { Id = 4, FirstName = "FourthSeller", LastName = "FourthSellerL"},
                new Seller { Id = 5, FirstName = "FifthSeller" , LastName = "FifthSellerL" }
            };
            foreach (var author in sellers)
                context.Sellers.Add(author);

            var buyers = new Buyer[]
            {
                new Buyer { Id = 1, FirstName = "FirdtBuyer" , LastName = "FirdtBuyerL" },
                new Buyer { Id = 2, FirstName = "SecondBuyer", LastName = "SecondBuyerL"},
                new Buyer { Id = 3, FirstName = "ThirdBuyer" , LastName = "ThirdBuyerL" },
                new Buyer { Id = 4, FirstName = "FourthBuyer", LastName = "FourthBuyerL"},
                new Buyer { Id = 5, FirstName = "FifthBuyer" , LastName = "FifthBuyerL" }
            };
            foreach (var buyer in buyers)
                context.Buyers.Add(buyer);

            var salesI = new Sales[]
            {
                new Sales { Id = 1, Date = new System.DateTime(2020,04,03), MoneySum= 900, Buyer = buyers[0], Seller = sellers[0] },
                new Sales { Id = 2, Date = new System.DateTime(2020,04,03), MoneySum= 800, Buyer = buyers[1], Seller = sellers[1] },
                new Sales { Id = 3, Date = new System.DateTime(2020,04,03), MoneySum= 700, Buyer = buyers[2], Seller = sellers[2] },
                new Sales { Id = 4, Date = new System.DateTime(2020,04,03), MoneySum= 600, Buyer = buyers[3], Seller = sellers[3] },
                new Sales { Id = 5, Date = new System.DateTime(2020,04,03), MoneySum= 500, Buyer = buyers[4], Seller = sellers[4] }
            };
            foreach (var sale in salesI)
                context.SalesInfos.Add(sale);

            base.Seed(context);
        }
    }
}
