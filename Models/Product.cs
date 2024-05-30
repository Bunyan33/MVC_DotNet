using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_DotNet.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal Price { get; set; }
        public int Qty { get; set; }
    }
}