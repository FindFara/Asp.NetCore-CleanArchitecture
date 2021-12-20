using Microsoft.EntityFrameworkCore;
using Programer.Core.Interface;
using Programer.Core.ViewModels.ProductGroups;
using Programer.DataEF.ProgramersContext;
using Programer.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.Services
{
    public interface IProductGroupService : IGenericService<int, ProductGroupIndexVm, ProductGroupCreateOrEditVm>
    {

    }
    public class ProductGroupService : IProductGroupService
    {
        private readonly ProgramerContext _context;

        public ProductGroupService(ProgramerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ProductGroupCreateOrEditVm vm)
        {
            try
            {
                _context.ProductGroups.Add(new ProductGroup
                {
                    Id = vm.Id,
                    CreateDate = DateTime.Now,
                    ProductGroupTitle = vm.Title
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
                var productGroup = await _context.ProductGroups.FindAsync(id);
                _context.ProductGroups.Remove(productGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(ProductGroupCreateOrEditVm vm)
        {
            try
            {
                var productGroup = await _context.ProductGroups.FindAsync(vm.Id);
                productGroup.ProductGroupTitle = vm.Title;
                productGroup.LastModifyDate = DateTime.Now;
                _context.ProductGroups.Update(productGroup);
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
            return await _context.ProductGroups.AnyAsync(e => e.Id == id);
        }

        public async Task<ProductGroupCreateOrEditVm> FindAsync(int id)
        {
            var model = await _context.ProductGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<ProductGroupIndexVm>> GetAllAsync()
        {
            return await _context.ProductGroups.ToIndexViewModel().ToListAsync();
            //var result=  await _context.ProductGroups.ToListAsync();
            //var vm= result.ToIndexViewModel().ToList();
            //return vm;
        }
    }
}

