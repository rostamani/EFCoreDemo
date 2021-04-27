using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.Product
{
    public class CreateProduct
    {
        public string Name { get; set; }

        public double UnitPrice { get; set; }

        public int CategoryId { get; set; }
    }
}
