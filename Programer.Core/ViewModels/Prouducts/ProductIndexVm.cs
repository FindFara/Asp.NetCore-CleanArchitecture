using Programer.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Prouducts
{
    public class ProductIndexVm : IAdminIndexViewModel<int>
    {
        public int Id { get; set; }

        [Display(Name = "Group name ")]
        public string GroupName { get; set; }

        [Display(Name = "Product name ")]
        public string Name { get; set; }

        [Display(Name = "Product price ")]
        public int Price { get; set; }

        [Display(Name = "Discount")]
        public int Discount { get; set; }

        [Display(Name = " Create date")]
        public DateTime CreateDate { get; set; }

        [Display(Name = " Modify date")]
        public DateTime? LastModifyDate { get; set; }
    }
}
