using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFCore.Application.Contracts.ProductCategory;
using EFCore.Domain.ProductCategoryAgg;
using EFCore.Helpers.Convertors;

namespace EFCore.Infrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly EfContext _db;

        public ProductCategoryRepository(EfContext db)
        {
            _db = db;
        }

        public EditProductCategory GetDetails(int id)
        {
            return _db.ProductCategories.Select(c => new EditProductCategory()
            {
                Name = c.Name,
                Id = c.Id
            }).FirstOrDefault(c => c.Id == id);
        }

        public void Create(ProductCategory productCategory)
        {
            _db.ProductCategories.Add(productCategory);
            SaveChanges();
        }

        public bool Exists(string name)
        {
            return _db.ProductCategories.Any(c => c.Name == name);
        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            var query = _db.ProductCategories.Select(c => new ProductCategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                CreationDate = c.CreationDate.ToPersianDate()
            });

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            return query.OrderBy(c => c.Name).ThenByDescending(c => c.Id).ToList();
        }

        public ProductCategory Get(int id)
        {
            return _db.ProductCategories.FirstOrDefault(c => c.Id == id);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}
