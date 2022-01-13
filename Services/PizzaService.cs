using contossoPizza.Models;
using System.Collections.Generic;

namespace contossoPizza.Services{

    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; }
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }

        public static List<Pizza> GetAll() => Pizzas;

        public static Pizza? Get(int id) {
            Pizza pizza = null;
            foreach( Pizza p in Pizzas){
                if(p.Id == id){
                    pizza = p;
                    break;
                }
            }

            return pizza;
        }

        public static void Add(Pizza pizza)
        {
            int nextId = Pizzas.Count;
            pizza.Id = ++nextId;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if(pizza is null)
                return;

            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if(index == -1)
                return;

            Pizzas[index] = pizza;
        }
    }
}
