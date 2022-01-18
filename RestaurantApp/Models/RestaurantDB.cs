using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RestaurantApp.Models
{
    public partial class RestaurantDB : DbContext
    {
        public RestaurantDB()
            : base("name=RestaurantDB")
        {
        }
        public virtual DbSet<Waiter> Waiters { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
