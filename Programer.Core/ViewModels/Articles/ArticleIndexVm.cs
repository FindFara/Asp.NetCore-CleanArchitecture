using Programer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Articles
{
    public class ArticleIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }

        [Display(Name = "Group name ")]
        public string GroupName { get; set; }

        [Display(Name = "Article name ")]
        public string Name { get; set; }

        [Display(Name = "Article Writer ")]
        public string Writer { get; set; }

        [Display(Name = " Create date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = " Modify date")]
        public DateTime? LastModifyDate { get; set; }
    
    }
}
