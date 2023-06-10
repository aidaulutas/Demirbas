using DemirbasData.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasData.DataContext
{
    public class DemirbasContext : DbContext
    {
        public DemirbasContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<DeliveryHistory> DeliveryHistories { get; set;}
        public DbSet<ItemType> ItemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        }
}
