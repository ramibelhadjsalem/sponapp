using Microsoft.EntityFrameworkCore;
using sponapp.Entities;

namespace sponapp.Data
{
    public class DataContext : DbContext
    {


        
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
        DbSet<FoodItem> foodItems { get; set; }
    }
}
