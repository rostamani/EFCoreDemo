using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Domain.ProductAgg
{
    public interface IProductRepository
    {
        void Create(Product product);

        Product Get(int id);

    }
}
