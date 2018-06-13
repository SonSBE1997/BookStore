using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    [Serializable]
    public class CartItem
    {
        public Book BookPur { get; set; }

        public int Quantity { get; set; }
    }
}