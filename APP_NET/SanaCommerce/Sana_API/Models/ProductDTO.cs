using _3.Models.Models;

namespace Sana_API.Models
{
    public class ProductDTO
    {

        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Categories { get; set; } = null!;

        //public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        //public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    }
}
