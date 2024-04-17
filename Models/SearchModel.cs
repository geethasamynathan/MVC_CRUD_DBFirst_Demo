using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVC_CRUD_DBFirst_Demo.Models
{
    public class SearchModel
    {
        //private readonly QuickKartContext _context;

        //public SearchModel(QuickKartContext context)
        //{
        //    _context = context;
        //}
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        [Key]
        public int SearchId { get;set; }
        //public List<Product> Products { get;set; }

        //public List<Product> OnGet()
        //{
        //    if (!string.IsNullOrWhiteSpace(SearchTerm) && SearchTerm.Length >= 3)
        //    {
        //        // Your logic to fetch products based on the search term
        //        Products = _context.Products.Where(p => p.ProductName == SearchTerm).ToList();
        //    }
        //    else
        //    {
        //        Products = null;
        //    }
        //    return Products;
        //}
    }
}

