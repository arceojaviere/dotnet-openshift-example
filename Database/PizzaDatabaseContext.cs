using contossoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace contossoPizza.Database
{
    public class PizzaDatabaseContex : DbContext
    {
        public PizzaDatabaseContex(DbContextOptions<PizzaDatabaseContex> options) : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }
    }
}