using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.Core.ViewModels.Products
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductGroupName { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public int FinalPrice => Price - Discount;
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

    }
}
