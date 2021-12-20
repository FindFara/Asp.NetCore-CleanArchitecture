using Programer.Domain.Base;
using Programer.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Domain.Entities.Orders
{
    public class OrderDetail:BaseEntity<long>
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        #region Relations
        
        public Order Order { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
