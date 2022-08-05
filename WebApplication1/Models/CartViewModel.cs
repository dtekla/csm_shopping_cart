using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal GrandTotal { get; set; }

    }
}
