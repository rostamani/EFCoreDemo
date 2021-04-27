using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Application.Contracts.ProductCategory;

namespace EFCore.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        ProductCategory Get(int id);
        List<ProductCategoryViewModel> Search(string name);
        EditProductCategory GetDetails(int id);

        void Create(ProductCategory productCategory);
        void SaveChanges();

        bool Exists(string name);
        
       
    }
}
