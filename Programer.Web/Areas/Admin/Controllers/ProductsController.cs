using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programer.Core.Services;
using Programer.Core.ViewModels.Products;
using Programer.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programer.Web.Areas.Admin.Controllers
{
    public class ProductController : AdminController
    {
        private readonly IProductService _pruductService;

        public ProductController(IProductService pruductService)
        {
            _pruductService = pruductService;
        }
        // GET: Admin/ProductGroups
        public async Task<IActionResult> Index()
        {
            return View(await _pruductService.GetAllAsync());
        }

        // GET: Admin/ProductGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGroup = await _pruductService.FindAsync(id.Value);
            if (bookGroup == null)
            {
                return NotFound();
            }

            return View(bookGroup);
        }

        // GET: Admin/ProductGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new ProductCreateOrEditVm());
        }

        // POST: Admin/ProductGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ProductCreateOrEditVm product)
        {
            if (ModelState.IsValid)
            {
                await _pruductService.AddAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/ProductGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _pruductService.FindAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit", product);
        }

        // POST: Admin/ProductGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCreateOrEditVm Product)
        {
            if (id != Product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _pruductService.EditAsync(Product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _pruductService.Exists(Product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", Product);
        }

        // GET: Admin/ProductGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Product = await _pruductService.FindAsync(id.Value);
            if (Product == null)
            {
                return NotFound();
            }

            return View(Product);
        }

        // POST: Admin/ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pruductService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductGroupExists(int id)
        //{
        //    return _context.ProductGroups.Any(e => e.Id == id);
        //}

    }

}

