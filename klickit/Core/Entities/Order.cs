namespace klickit.Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice {  get; set; }
        public Status Status { get; set; }

        public List<OrderedItems> Items { get; set; }


    }
    public enum Status
    {
        requested =1,
        approved=2,
        rejected=3
    }

}

