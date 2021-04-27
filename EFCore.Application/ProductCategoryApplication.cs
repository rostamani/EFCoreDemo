using System;
using System.Collections.Generic;
using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;

namespace EFCore.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public void Create(CreateProductCategory command)
        {
            if (!_productCategoryRepository.Exists(command.Name))
            {
                var productCategory = new ProductCategory(command.Name);
                _productCategoryRepository.Create(productCategory);
                _productCategoryRepository.SaveChanges();
            }
        }

        public void Edit(EditProductCategory command)
        {
            var productCategory = _productCategoryRepository.Get(command.Id);
            if (productCategory!=null)
            {
                productCategory.Edit(command.Name);
                _productCategoryRepository.SaveChanges();

            }
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            return _productCategoryRepository.Search(name);
        }

        public EditProductCategory GetDetails(int id)
        {
            return _productCategoryRepository.GetDetails(id);
        }
    }
}
