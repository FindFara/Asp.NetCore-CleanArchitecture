using Microsoft.EntityFrameworkCore;
using Programer.Core.Interface;
using Programer.Core.ViewModels.ArticleGroups;
using Programer.DataEF.ProgramersContext;
using Programer.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Services
{
    public interface IArticleGroupService : IGenericService<int, ArticleGroupIndexVm, ArticleGroupCreateOrEditVm>
    {

    }
    public class ArticleGroupService : IArticleGroupService
    {
        private readonly ProgramerContext _context;

        public ArticleGroupService(ProgramerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ArticleGroupCreateOrEditVm vm)
        {
            try
            {
                _context.ArticleGroups.Add(new ArticleGroup
                {
                    Id = vm.Id,
                    CreateDate = DateTime.Now,
                    ArticleTitle = vm.Title
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

        public async Task<bool> EditAsync(ArticleGroupCreateOrEditVm vm)
        {
            try
            {
                var productGroup = await _context.ArticleGroups.FindAsync(vm.Id);
                productGroup.ArticleTitle = vm.Title;
                productGroup.LastModifyDate = DateTime.Now;
                _context.ArticleGroups.Update(productGroup);
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
            return await _context.ArticleGroups.AnyAsync(e => e.Id == id);
        }

        public async Task<ArticleGroupCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.ArticleGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<ArticleGroupIndexVm>> GetAllAsync()
        {
            return await _context.ArticleGroups.ToIndexViewModel().ToListAsync();
            //var result=  await _context.ArticleGroups.ToListAsync();
            //var vm= result.ToIndexViewModel().ToList();
            //return vm;
        }
    }
}
