using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using contossoPizza.Database;
using contossoPizza.Models;

using System.Linq; 

namespace ContosoPizza.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {

        private PizzaDatabaseContex _databaseContex;
        public PizzaController(PizzaDatabaseContex databaseContex)
        {
            _databaseContex = databaseContex;
        }

        // GET all action
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll(){
            List<Pizza> pizzas = new List<Pizza>{};
            System.Console.WriteLine("Context: " + _databaseContex);

            foreach(Pizza p in _databaseContex.Pizzas){
                pizzas.Add(p);
            }

            return _databaseContex.Pizzas.ToList();
        }
            

        // GET by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            Pizza pizza = _databaseContex.Pizzas.Find(id);

            if(pizza == null)
                return NotFound();

            return pizza;
        }

        // POST action

        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {   
            int id = _databaseContex.Pizzas.Count() + 1;
            pizza.Id = id;
            _databaseContex.Pizzas.Add(pizza);
            _databaseContex.SaveChanges();
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }


        // PUT action

        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            Pizza existingPizza = _databaseContex.Pizzas.Find(id);
            if(existingPizza is null)
                return NotFound();

            existingPizza.Name = pizza.Name;
            existingPizza.IsGlutenFree = pizza.IsGlutenFree;

            _databaseContex.Pizzas.Update(existingPizza);

            _databaseContex.SaveChanges();      

            return NoContent();
        }


        // DELETE action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pizza pizza = _databaseContex.Pizzas.Find(id);

            if (pizza is null)
                return NotFound();

            _databaseContex.Remove(pizza);

            _databaseContex.SaveChanges();

            return NoContent();
        }

    }
}