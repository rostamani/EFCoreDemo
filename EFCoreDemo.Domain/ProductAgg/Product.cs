using System;
using EFCore.Domain.ProductCategoryAgg;

namespace EFCore.Domain.ProductAgg
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreationDate { get; set; }


        public int CategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; }

        public Product(string name,double unitPrice,int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CreationDate = DateTime.Now;
            CategoryId = categoryId;
        }

        public void Edit(string name, double unitPrice, int categoryId)
        {
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId;
        }

        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }

    }
}
