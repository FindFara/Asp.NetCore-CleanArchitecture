using Microsoft.AspNetCore.Mvc;
using Programer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programer.Web.Controler
{
    
    public class ProductGroupsController : Controller
    {

        private readonly IProductService _productService;
        private readonly IProductGroupService _productGroupService;
        public ProductGroupsController(IProductService productService, IProductGroupService productGroupService)
        {
            _productService = productService;
            _productGroupService = productGroupService;
        }

        [Route("p/{id}/{title}")] 
        public async Task<IActionResult> Index(int id,string title , int page)
        {
            return View(Tuple.Create(
                await _productGroupService.FindAsync(id),
                _productService.GetProductByGroupId(id,page)
                ));
        }
    }
}
