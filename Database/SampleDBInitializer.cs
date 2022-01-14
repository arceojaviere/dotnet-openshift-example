using contossoPizza.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace contossoPizza.Database
{
    public static class SampleDatabaseInitilizer{
        public static void InitializeDB(PizzaDatabaseContex ctx){

            ctx.Database.EnsureCreated();

            if (ctx.Pizzas.Any())
            {
                return; 
            }

            List<Pizza> Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };

            foreach(Pizza p in Pizzas){
                ctx.Pizzas.Add(p);
            }

            ctx.SaveChanges();

        }
    }
}