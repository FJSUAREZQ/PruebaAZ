using _3.Models.Models;

namespace Sana_API.Models
{
    public class OrderDTO
    {
        public int? OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalAmount { get; set; }


        public List<OrderDetailDTO> OrderDetailsDTO { get; set; } = new List<OrderDetailDTO>();

    }
}
