namespace Sana_API.Models
{
    public class OrderDetailDTO
    {
        public int? DetailId { get; set; }

        public int? OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Subtotal { get; set; }

    }
}
