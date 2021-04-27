using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.Product;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EFCoreDemo.Web.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductApplication productApplication, IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public SelectList Categories { get; set; }

        [BindProperty]
        public CreateProduct CreateProduct { get; set; }

        public void OnGet()
        {
            Categories=new SelectList(_productCategoryApplication.Search(""),"Id","Name");
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _productApplication.Create(CreateProduct);
                return RedirectToPage("Index");
            }
            return RedirectToPage("Create");
        }
    }
}
