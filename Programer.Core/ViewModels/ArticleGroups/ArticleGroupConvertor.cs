using Programer.Core.ViewModels.ProductGroups;
using Programer.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.ArticleGroups
{
    public static class ArticleGroupConvertor
    {
        public static ArticleGroupCreateOrEditVm ToCreateOrEditViewModel(this ArticleGroup group)
        {
            return new ArticleGroupCreateOrEditVm
            {
                CreateDate = group.CreateDate,
                Id = group.Id,
                Title = group.ArticleTitle
                //LastModifyDate = group.LastModifyDate
            };
        }
        public static IQueryable<ArticleGroupCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToCreateOrEditViewModel());
        }

        public static ArticleGroupIndexVm ToIndexViewModel(this ArticleGroup group)
        {
            return new ArticleGroupIndexVm
            {
                Id = group.Id,
                Title = group.ArticleTitle,
                CreateDate = group.CreateDate,
                LastModifyDate = group.LastModifyDate
            };
        }
        public static IEnumerable<ArticleGroupIndexVm> ToIndexViewModel(this IEnumerable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ArticleGroupIndexVm> ToIndexViewModel(this IQueryable<ArticleGroup> groups)
        {
            return groups.Select(c => c.ToIndexViewModel());
        }
    }
}
