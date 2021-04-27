using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }

    }
}
