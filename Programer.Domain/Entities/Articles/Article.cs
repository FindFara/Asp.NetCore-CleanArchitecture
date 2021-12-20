
using Programer.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Domain.Entities.Articles
{
    public class Article: BaseEntity<int>, IAuditable
    {
        public int ArticleGroupId { get; set; }  
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Writer { get; set; }
        [Required]
        [MaxLength(500)]
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion
        #region Relations
        public ArticleGroup ArticleGroup { get; set; }
        #endregion
    }
}
