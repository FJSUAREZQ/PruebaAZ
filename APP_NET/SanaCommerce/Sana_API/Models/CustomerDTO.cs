using _3.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Sana_API.Models
{
    public class CustomerDTO
    {
        public int CustomerId { get; set; }

        [RegularExpression(@"^[A-Za-zÑñÁáÉéÍíÓóÚú ]+", ErrorMessage = "Invalid format")]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string FirstName { get; set; } = null!;


        [RegularExpression(@"^[A-Za-zÑñÁáÉéÍíÓóÚú ]+", ErrorMessage = "Invalid format")]
        [StringLength(50, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string LastName { get; set; } = null!;


        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "It is not a email format.")]
        [StringLength(80, ErrorMessage = "The {0} value cannot exceed {1} characters.")]
        public string? Email { get; set; }


       // public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
