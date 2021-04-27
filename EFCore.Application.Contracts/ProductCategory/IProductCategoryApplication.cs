using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory command);
        void Edit(EditProductCategory command);
        List<ProductCategoryViewModel> Search(string name);
        EditProductCategory GetDetails(int id);
    }
}
