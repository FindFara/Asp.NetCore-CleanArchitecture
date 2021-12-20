using Programer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Prouducts
{
    public class ProductCreateOrEditVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }
        [Display(Name = "Group name ")]
        public int ProductGroupId { get; set; }

        [Display(Name = "Product name ")]
        [Required(ErrorMessage = "Enter the {0}")]
        public string Name { get; set; }

        [Display(Name = "Product price ")]
        [Required(ErrorMessage = " Enter the {0}")]
        [Range(1000, 9999999, ErrorMessage = "لطفا {0} را بین {1} و {2} نمایش دهید")]
        public int Price { get; set; }

        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [Display(Name = "ShortDescription")]
        public string ShortDescription { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
