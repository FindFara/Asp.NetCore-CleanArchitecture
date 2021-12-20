using Programer.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Domain.Entities.Products
{
     public class ProductGroup: BaseEntity<int>, IAuditable
    {
        [Required]
        [MaxLength(50)]
        public string ProductGroupTitle { get; set; }

        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion
        #region Relations
        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
