using DemirbasData.Identity;
using DemirbasData.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemirbasData.DataContext
{
    public class DemirbasContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private readonly DbContextOptions _options;
        public DemirbasContext(DbContextOptions<DemirbasContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DeliveryHistory> DeliveryHistories { get; set;}
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Return> Returns { get; set; }

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
