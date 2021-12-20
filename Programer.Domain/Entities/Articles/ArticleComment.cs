using Programer.Domain.Base;
using Programer.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Domain.Entities.Articles
{
    public class ArticleComment:BaseEntity<long>,IAuditable
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
        [Required]
        [MaxLength(500)]
        public string Message { get; set; }

        #region Auditable
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        #endregion
        #region Relations
        public Article Article { get; set; }
        public User User { get; set; }
        #endregion
    }
}
