using Programer.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.ProductGroups
{
    public static  class ProductGroupConvertor
    {
        public static ProductGroupCreateOrEditVm ToCreateOrEditViewModel(this ProductGroup group)
        {
            return new ProductGroupCreateOrEditVm
            {
                CreateDate = group.CreateDate,
                Id = group.Id,
                Title = group.ProductGroupTitle
                //LastModifyDate = group.LastModifyDate
            };
        }
        public static IQueryable<ProductGroupCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<ProductGroup> groups)
        {
            return groups.Select(c => c.ToCreateOrEditViewModel());
        }

        public static ProductGroupIndexVm ToIndexViewModel(this ProductGroup group)
        {
            return new ProductGroupIndexVm
            {
                Id = group.Id,
                Title = group.ProductGroupTitle,
                CreateDate = group.CreateDate,
                LastModifyDate = group.LastModifyDate
            };
        }
        public static IEnumerable<ProductGroupIndexVm> ToIndexViewModel(this IEnumerable<ProductGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ProductGroupIndexVm> ToIndexViewModel(this IQueryable<ProductGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
    }
}
