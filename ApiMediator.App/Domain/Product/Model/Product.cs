using ApiMediator.Core.Base.Model;

namespace ApiMediator.App.Domain.Product.Model
{
    public class Product : Entity
    {
        public Product() { }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
