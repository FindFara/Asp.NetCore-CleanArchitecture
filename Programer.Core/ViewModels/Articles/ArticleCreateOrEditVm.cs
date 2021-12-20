using Programer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Articles
{
    public class ArticleCreateOrEditVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name = "Group name ")]
        public int GroupId { get; set; }

        [Display(Name = "Article name ")]
        [Required(ErrorMessage = "Enter the {0}")]
        public string Name { get; set; }

        [Display(Name = "writer")]
        //[Required(ErrorMessage = " Enter the {0}")]
        public string writer { get; set; }

        [Display(Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }


    }
}
