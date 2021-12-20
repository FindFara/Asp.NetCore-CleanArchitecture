using Programer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.ArticleGroups
{
    public class ArticleGroupIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name = "Group name")]
        public string Title { get; set; }
        [Display(Name = "Create date")]
        public DateTime CreateDate { get; set; }
        [Display(Name = "Modofy date")]
        public DateTime? LastModifyDate { get; set; }
    }
}