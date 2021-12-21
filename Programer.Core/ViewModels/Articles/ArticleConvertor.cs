using Programer.Core.Interface;
using Programer.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Articles
{
    public static class ArticleConvertor 
    {
        #region ToCreateOrEditViewModel

        public static ArticleCreateOrEditVm ToCreateOrEditViewModel(this Article Article)
        {
            if (Article == null) return null;
            return new ArticleCreateOrEditVm
            {
                Id = Article.Id,
                GroupId = Article.ArticleGroupId,
                Name = Article.Name,
                Writer = Article.Writer,
                ShortDescription = Article.ShortDescription,
                Description = Article.Description,
                CreateDate=Article.CreateDate
            };
        }

        public static IQueryable<ArticleCreateOrEditVm> ToCreateOrEditViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToCreateOrEditViewModel());
        }
      
        #endregion


        #region ToIndexViewModel

        public static ArticleIndexVm ToIndexViewModel(this Article Article)
        {
            if (Article == null) return null;
            return new ArticleIndexVm
            {
                Id = Article.Id,
                Name = Article.Name,
                Writer = Article.Writer,
                CreateDate = Article.CreateDate,
                LastModifyDate = Article.LastModifyDate,
                ArticleGroup = Article.ArticleGroup?.ArticleTitle,
            };
        }
        public static IEnumerable<ArticleIndexVm> ToIndexViewModel(this IEnumerable<Article> Articles)
        {
            return Articles.Select(c => c.ToIndexViewModel());
        }
        public static IQueryable<ArticleIndexVm> ToIndexViewModel(this IQueryable<Article> Articles)
        {
            return Articles.Select(c => c.ToIndexViewModel());
        }

        #endregion
    }
}
