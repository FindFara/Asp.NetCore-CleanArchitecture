using Programer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.ProductGroups
{
    public class ProductGroupCreateOrEditVm : IAdminCreateOrEditViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name = "Product Group name")]
        [Required(ErrorMessage = "Enter the {0}")]
        public string Title { get; set; }
        [Display(Name = "Create date")]
        public DateTime CreateDate { get; set; }
    }
    
    
}
