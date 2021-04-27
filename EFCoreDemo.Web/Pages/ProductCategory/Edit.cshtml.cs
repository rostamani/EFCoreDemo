using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreDemo.Web.Pages.ProductCategory
{
    public class EditModel : PageModel
    {
        private readonly IProductCategoryApplication _productCategoryApplication;

        public EditModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }

        [BindProperty]
        public EditProductCategory EditProductCategory { get; set; }

        public void OnGet(int id)
        {
            EditProductCategory = _productCategoryApplication.GetDetails(id);
        }

        public IActionResult OnPost(/*EditProductCategory command*/)
        {
            _productCategoryApplication.Edit(EditProductCategory);
            return RedirectToPage("Index");
        }
    }
}
