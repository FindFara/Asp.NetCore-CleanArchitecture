using Microsoft.EntityFrameworkCore;
using Programer.Core.Interface;
using Programer.Core.Statics;
using Programer.Core.ViewModels.ProductGroups;
using Programer.Core.ViewModels.Products;
using Programer.DataEF.ProgramersContext;
using Programer.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Programer.Core.Services
{
    public interface IProductService : IGenericService<int, ProductIndexVm, ProductCreateOrEditVm>
    {
        IPagedList<ProductDetail> GetProductByGroupId(int groupId, int page = 1);
    }

    public class ProductService: IProductService
    {
        private readonly ProgramerContext _context;

        public ProductService(ProgramerContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ProductCreateOrEditVm vm)
        {
            try
            {
                _context.Products.Add(new Product
                {
                    Id = vm.Id,
                    ProductGroupId = vm.ProductGroupId,
                    Name = vm.Name,
                    Price = vm.Price,
                    Description = vm.Description,
                    Discount = vm.Discount,
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
                var product = await _context.Products.FindAsync(id);
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> EditAsync(ProductCreateOrEditVm vm)
        {
            try
            {
                var Product = await _context.Products.FindAsync(vm.Id);
                Product.Name = vm.Name;
                Product.Price = vm.Price;
                Product.ShortDescription = vm.ShortDescription;
                Product.Description = vm.Description;
                Product.Discount = vm.Discount;
                Product.ProductGroupId = vm.ProductGroupId;
                Product.LastModifyDate = DateTime.Now;
                _context.Products.Update(Product);
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
            return await _context.Products.AnyAsync(e => e.Id == id);
        }

        public async Task<ProductCreateOrEditVm> FindAsync(int id)
        {

            var model = await _context.Products
           .FirstOrDefaultAsync(m => m.Id == id);
            return model.ToCreateOrEditViewModel();
        }

        public async Task<List<ProductIndexVm>> GetAllAsync()
        {
            return await _context.Products.ToIndexViewModel().ToListAsync();
        }

        public IPagedList<ProductDetail> GetProductByGroupId(int groupId, int page = 1)
        {
            return _context.Products
                .Where(c=> c.ProductGroupId==groupId)
                .Select(c => c.ToDetailViewModel())
                .ToPagedList(page, Values.PageSize);
        }
    }
}




