namespace HelloWorld.Models
{
    public class MarketingProduct
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public int Inventory { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }

        public MarketingProduct(string name, double price, double discountPrice) {
          Name = name;
          Price = price;
          DiscountPrice = discountPrice;
          Inventory = 0;
          Active = true;
          CreatedAt = DateTime.Now;
        }

        public MarketingProduct(int id, string name, double price, double discountPrice, int inventory, bool active, DateTime createdAt)
        {
          Id = id;
          Name = name;
          Price = price;
          DiscountPrice = discountPrice;
          Inventory = inventory;
          Active = active;
          CreatedAt = createdAt;
        }
    }
}