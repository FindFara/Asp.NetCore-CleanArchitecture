using Programer.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Products
{
    public static class ProductConvertor
    { 
        #region ToDetailViewModel

        public static ProductDetail ToDetailViewModel(this Product product)
        {
            if (product == null) return null;
            return new ProductDetail
            {
                Id = product.Id,
                ProductGroupId = product.ProductGroupId,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                ProductGroupName=product.ProductGroup?.ProductGroupTitle
                
            };
        }

        public static IQueryable<ProductDetail> ToDetailViewModel(this IQueryable<Product> products)
        {
            return products.Select(c => c.ToDetailViewModel());
        }

        #endregion


        #region ToCreateOrEditViewModel

        public static ProductCreateOrEditVm ToCreateOrEditViewModel(this Product product)
        {
            if (product == null) return null;
            return new ProductCreateOrEditVm
            {
                Id = product.Id,
                ProductGroupId = product.ProductGroupId,
                Name = product.Name,
                ShortDescription = product.ShortDescription,
                Description = product.Description,
                Price = product.Price,
                Discount = product.Discount,
                CreateDate = product.CreateDate
            };
        }

        public static IQueryable<ProductCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<Product> products)
        {
            return products.Select(c => c.ToCreateOrEditViewModel());
        }

        #endregion


        #region ToIndexViewModel

        public static ProductIndexVm ToIndexViewModel(this Product product)
        {
            if (product == null) return null;
            return new ProductIndexVm
            {
                Id = product.Id,
                CreateDate = product.CreateDate,
                LastModifyDate = product.LastModifyDate,
                GroupName = product.ProductGroup?.ProductGroupTitle,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
               
            };
        }
        public static IEnumerable<ProductIndexVm> ToIndexViewModel(this IEnumerable<Product> products)
        {
            return products.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ProductIndexVm> ToIndexViewModel(this IQueryable<Product> products)
        {
            return products.Select(c => c.ToIndexViewModel());
        }

        #endregion
    }
}  


