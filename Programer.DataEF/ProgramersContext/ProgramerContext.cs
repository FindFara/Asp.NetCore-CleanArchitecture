using Microsoft.EntityFrameworkCore;
using Programer.Domain.Entities.Articles;
using Programer.Domain.Entities.Orders;
using Programer.Domain.Entities.Products;
using Programer.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programer.DataEF.ProgramersContext
{
    public class ProgramerContext : DbContext
    {
        public ProgramerContext(DbContextOptions<ProgramerContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleGroup> ArticleGroups { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductComment> ProductComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }
}