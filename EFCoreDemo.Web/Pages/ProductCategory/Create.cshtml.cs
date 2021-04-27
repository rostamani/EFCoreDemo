using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreDemo.Web.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public CreateModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost(CreateProductCategory command)
        {
            _productCategoryApplication.Create(command);
            return RedirectToPage("Index");
        }
    }
}
