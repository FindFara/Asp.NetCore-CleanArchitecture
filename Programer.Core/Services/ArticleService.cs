using Microsoft.EntityFrameworkCore;
using Programer.Core.Interface;
using Programer.Core.ViewModels.Articles;
using Programer.Core.ViewModels.Products;
using Programer.DataEF.ProgramersContext;
using Programer.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Services
{

    public interface IArticleService : IGenericService<int, ArticleIndexVm,ArticleCreateOrEditVm>
    {

    }

    public class ArticleService : IArticleService
    {
        private readonly ProgramerContext _context;

        public ArticleService(ProgramerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ArticleCreateOrEditVm vm)
        {
            try
            {
                _context.Articles.Add(new Article
                {
                    Id = vm.Id,
                    ArticleGroupId = vm.GroupId,
                    Name = vm.Name,
                    Writer = vm.Writer,
                    Description = vm.Description,
                    ShortDescription = vm.ShortDescription,
                    CreateDate = DateTime.Now,

                });
                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var productGroup = await _context.ArticleGroups.FindAsync(id);
                _context.ArticleGroups.Remove(productGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(ArticleCreateOrEditVm vm)
        {
            try
            {
                var Article = await _context.Articles.FindAsync(vm.Id);
                Article.Name = vm.Name;
                Article.Writer = vm.Writer;
                Article.ShortDescription = vm.ShortDescription;
                Article.Description = vm.Description;
                Article.ArticleGroupId = vm.GroupId;
                Article.LastModifyDate = DateTime.Now;
                _context.Articles.Update(Article);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Articles.AnyAsync(e => e.Id == id);
        }

        public async Task<ArticleCreateOrEditVm> FindAsync(int id)
        {

            var model = await _context.Articles
           .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<ArticleIndexVm>> GetAllAsync()
        {
            return await _context.Articles.ToIndexViewModel().ToListAsync();
        }
    }
}






