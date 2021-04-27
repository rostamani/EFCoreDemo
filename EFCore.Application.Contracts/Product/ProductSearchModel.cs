using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.Product
{
    public class ProductSearchModel
    {
        public bool IsRemoved { get; set; }
        public string Name { get; set; }
    }
}
