using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.Product
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }

    }
}
