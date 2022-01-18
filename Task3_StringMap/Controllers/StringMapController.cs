using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task3_StringMap.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task3_StringMap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringMapController : ControllerBase
    {
        // GET: api/<StringMapController>
        [HttpDelete]
        public IActionResult Delete(Dog dog)
        {
            var myDogsCustomCollection = new StringMap<Dog>();

            //test with Dog Entity:
            myDogsCustomCollection.AddElement("Ringo", new Dog() { });
            myDogsCustomCollection.AddElement("Firulays", new Dog() { });
            myDogsCustomCollection.AddElement("NewDog", new Dog() { });

            myDogsCustomCollection.RemoveElement(dog.Name);
            string result = $"a dog was removed from the collection, now we have: {myDogsCustomCollection.Count} dogs";

            return Ok(result);
        }

        [HttpPost]
        public IActionResult post([FromBody] IEnumerable<Dog> dogs)
        {
            var myDogsCustomCollection = new StringMap<Dog>();
            foreach (var dog in dogs)
            {
                myDogsCustomCollection.AddElement(dog.Name, dog);
            }
            string result = $"{myDogsCustomCollection.Count} dog/s was added to the collection, " +
                $"now youe have: {myDogsCustomCollection.Count} dogs";

            return Ok(result);
        }


        [HttpGet]
        public IActionResult Get(string name)
        {
            
            var myDogsCustomCollection = new StringMap<Dog>();
            myDogsCustomCollection.SetDefaultValue(new Dog() { Name = "default dog", Age = 0 });
             
            
            //test with Dog Entity:
            myDogsCustomCollection.AddElement("Ringo", new Dog() { Name="ringo", Age=2});
            myDogsCustomCollection.AddElement("Firulays", new Dog() { Name = "Firulays", Age = 4 });
            myDogsCustomCollection.AddElement("NewDog", new Dog() { Name = "NewDog", Age = 0 });


            var result = myDogsCustomCollection.GetValue(name);
                        

            return Ok(result);
        }

    }
}
