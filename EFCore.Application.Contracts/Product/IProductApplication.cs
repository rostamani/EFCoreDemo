using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Application.Contracts.Product
{
    public interface IProductApplication
    {
        void Create(CreateProduct command);
        void Edit(EditProduct command);
        List<ProductViewModel> Search(string command);
        EditProduct GetDetails(int id);
        void Remove(int id);
        void Restore(int id);
    }
}
