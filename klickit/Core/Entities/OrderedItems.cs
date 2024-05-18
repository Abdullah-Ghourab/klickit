namespace klickit.Core.Entities
{
    public class OrderedItems
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
