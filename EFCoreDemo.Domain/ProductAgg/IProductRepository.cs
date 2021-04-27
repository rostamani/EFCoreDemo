using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Application.Contracts.Product;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {

        Product Get(int id);
        List<ProductViewModel> Search(string searchModel);
        EditProduct GetDetails(int id);
        bool Exists(string name, int categoryId);
        void Create(Product product);
        

        void SaveChanges();


    }
}
