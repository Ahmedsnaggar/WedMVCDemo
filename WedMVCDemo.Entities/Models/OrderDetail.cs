namespace WedMVCDemo.Entities.Models
{
    public class OrderDetail : MainModel
    {
        public int Id { get; set; }
        public int orderId { get; set; }
        public OrderHeader? order { get; set; }
        public int productId { get; set; }
        public Product? product { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double Discount { get; set; }
    }
}
