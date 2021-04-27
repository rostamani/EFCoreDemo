using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Application.Contracts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EFCoreDemo.Web.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;

        public IndexModel(IProductApplication productApplication)
        {
            _productApplication = productApplication;
        }

        public List<ProductViewModel> Products { get; set; }
        
        public void OnGet(string name)
        {
            Products = _productApplication.Search(name);
        }

        public IActionResult OnGetRemove(int id)
        {
            _productApplication.Remove(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetRestore(int id)
        {
            _productApplication.Restore(id);
            return RedirectToPage("Index");
        }
    }
}
