using System;
using System.Collections.Generic;
using System.Text;
using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;

namespace EFCore.Application
{
    public class ProductApplication:IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public void Create(CreateProduct command)
        {
            if (_productRepository.Exists(command.Name,command.CategoryId))
            {
                return;
            }

            var product=new Product(command.Name,command.UnitPrice,command.CategoryId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
        }

        public void Edit(EditProduct command)
        {
            var product = _productRepository.Get(command.ProductId);
            if (product!=null)
            {
                product.Edit(command.Name,command.UnitPrice,command.CategoryId);
                _productRepository.SaveChanges();
            }
        }

        public List<ProductViewModel> Search(ProductSearchModel command)
        {
            return _productRepository.Search(command);
        }

        public EditProduct GetDetails(int id)
        {
            return _productRepository.GetDetails(id);
        }

        public void Remove(int id)
        {
            var product = _productRepository.Get(id);
            product.Remove();
            _productRepository.SaveChanges();
        }

        public void Restore(int id)
        {
            var product = _productRepository.Get(id);
            product.Restore();
            _productRepository.SaveChanges();
        }
    }
}
