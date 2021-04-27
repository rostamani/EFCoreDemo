using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using EFCore.Domain.ProductAgg;

namespace EFCore.Domain.ProductCategoryAgg
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public List<Product> Products { get; set; }

        public ProductCategory(string name)
        {
            Name = name;
            CreationDate = DateTime.Now;
            Products =new List<Product>();
        }

        public void Edit(String name)
        {
            Name = name;
        }


    }
}
