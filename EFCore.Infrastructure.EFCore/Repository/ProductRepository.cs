using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore.Application.Contracts.Product;
using EFCore.Domain.ProductAgg;
using EFCore.Helpers.Convertors;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Infrastructure.EFCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EfContext _db;

        public ProductRepository(EfContext db)
        {
            _db = db;
        }

        public EditProduct GetDetails(int id)
        {
            return _db.Products.Select(p => new EditProduct()
            {
                Name = p.Name,
                ProductId = p.ProductId,
                CategoryId = p.CategoryId,
                UnitPrice = p.UnitPrice
            }).FirstOrDefault(p => p.ProductId == id);
        }

        public bool Exists(string name, int categoryId)
        {
            return _db.Products.Any(p => p.CategoryId == categoryId && p.Name == name);
        }

        public void Create(Product product)
        {
            _db.Products.Add(product);
            SaveChanges();

        }

        public List<ProductViewModel> Search(string searchModel)
        {
            var query = _db.Products.Include(p => p.ProductCategory)
                .Select(p => new ProductViewModel()
                {
                    Name = p.Name,
                    Category = p.ProductCategory.Name,
                    CreationDate = p.CreationDate.ToPersianDate(),
                    ProductId = p.ProductId,
                    UnitPrice = p.UnitPrice,
                    IsRemoved = p.IsRemoved
                });

            if ((!string.IsNullOrWhiteSpace(searchModel)))
            {
                query = query.Where(p => p.Name.Contains(searchModel));
            }

            return query.OrderBy(p => p.IsRemoved).ThenBy(p=>p.Name).ThenByDescending(p => p.ProductId).AsNoTracking().ToList();


        }

        public Product Get(int id)
        {
            return _db.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
