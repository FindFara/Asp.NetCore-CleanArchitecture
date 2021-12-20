using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Programer.Core.Services;
using Programer.Core.ViewModels.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programer.Web.Areas.Admin.Controllers
{
    public class ArticleController : AdminController
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService pruductService)
        {
            _articleService = pruductService;
        }
        // GET: Admin/ArticleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _articleService.GetAllAsync());
        }

        // GET: Admin/ArticleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookGroup = await _articleService.FindAsync(id.Value);
            if (bookGroup == null)
            {
                return NotFound();
            }

            return View(bookGroup);
        }

        // GET: Admin/ArticleGroups/Create
        public IActionResult Create()
        {
            return View("CreateOrEdit", new ArticleCreateOrEditVm());
        }

        // POST: Admin/ArticleGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ArticleCreateOrEditVm article)
        {
            if (ModelState.IsValid)
            {
                await _articleService.AddAsync(article);
                return RedirectToAction(nameof(Index));
            }
            return View(article);
        }

        // GET: Admin/ArticleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _articleService.FindAsync(id.Value);
            if (article == null)
            {
                return NotFound();
            }
            return View("CreateOrEdit", article);
        }

        // POST: Admin/ArticleGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ArticleCreateOrEditVm Article)
        {
            if (id != Article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _articleService.EditAsync(Article);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _articleService.Exists(Article.Id))
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
            return View("CreateOrEdit", Article);
        }

        // GET: Admin/ArticleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Article = await _articleService.FindAsync(id.Value);
            if (Article == null)
            {
                return NotFound();
            }

            return View(Article);
        }

        // POST: Admin/ArticleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _articleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
