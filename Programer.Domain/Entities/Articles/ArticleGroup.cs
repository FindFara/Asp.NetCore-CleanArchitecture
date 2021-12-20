using Programer.Domain.Base;
using Programer.Domain.Entities.Articles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Domain.Entities.Articles
{
    public class ArticleGroup : BaseEntity<int>, IAuditable
    {
        [Required]
        [MaxLength(50)]
        public string ArticleTitle { get; set; }

        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion

        #region Relations
        public ICollection<Article> Article { get; set; }
        #endregion
    }
}
