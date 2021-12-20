using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programer.Core.Services;
using Programer.Core.ViewModels.ProductGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programer.Web.Areas.Admin.Controllers
{
    public class ProductGroupsController : AdminController
    {
        //private readonly ShopContext _context;
        private readonly IProductGroupService _productGroupService;

        public ProductGroupsController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;
        }


        // GET: Admin/ProductGroups
        public async Task<IActionResult> Index()
        {
            return View(await _productGroupService.GetAllAsync());
        }

        // GET: Admin/ProductGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _productGroupService.FindAsync(id.Value);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // GET: Admin/ProductGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new ProductGroupCreateOrEditVm());
        }

        // POST: Admin/ProductGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( ProductGroupCreateOrEditVm productGroup)
        {
            if (ModelState.IsValid)
            {
                await _productGroupService.AddAsync(productGroup);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", productGroup);
        }

        // GET: Admin/ProductGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _productGroupService.FindAsync(id.Value);
            if (productGroup == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit", productGroup);
        }

        // POST: Admin/ProductGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ProductGroupCreateOrEditVm productGroup)
        {
            if (id != productGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productGroupService.EditAsync(productGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productGroupService.Exists(productGroup.Id))
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
            return View("CreateOrEdit", productGroup);
        }

        // GET: Admin/ProductGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productGroup = await _productGroupService.FindAsync(id.Value);
            if (productGroup == null)
            {
                return NotFound();
            }

            return View(productGroup);
        }

        // POST: Admin/ProductGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productGroupService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductGroupExists(int id)
        //{
        //    return _context.ProductGroups.Any(e => e.Id == id);
        //}
    }
}
