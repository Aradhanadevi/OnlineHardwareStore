namespace MVCtry1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    //👽👽
    public class CartItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int Quantity { get; set; } 
    }
}
