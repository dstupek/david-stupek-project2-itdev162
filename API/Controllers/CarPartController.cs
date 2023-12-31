using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CarPartController : ControllerBase
    {
        private readonly DataContext context;

        public CarPartController(DataContext context)
        {
            this.context = context;
        }
        //<SUMMARY>
        //Get CarPart
        //<returns> A list of CarParts</returns>
        [HttpGet(Name = "GetCarParts")]
        public ActionResult<List<CarPart>> Get()
        {
            return this.context.CarParts.ToList();
        }

        //Finds Carpart by ID
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<CarPart> GetById(Guid id)
        {
            var CarPart = this.context.CarParts.Find(id);
            if (CarPart is null)
            {
                return NotFound();
            }
            return Ok(CarPart);
        }

        // Creates a new car part 
        [HttpPost(Name = "Create")]
        public ActionResult<CarPart> Create([FromBody]CarPart request)
        {
            var CarPart = new CarPart
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Price = request.Price
            };

            context.CarParts.Add(CarPart);
            var success = context.SaveChanges() > 0;

            if (success)
            {
                return Ok(CarPart);
            }

            throw new Exception("Error creating car part");
        }

        // Updates car part
        [HttpPut(Name = "Update")]
        public ActionResult<CarPart> Update([FromBody]CarPart request)
        {
            var CarPart = context.CarParts.Find(request.Id);
            if (CarPart == null)
            {
                throw new Exception("Could not find car part");
            }

            //Update the Carpart properties with request values, if present
            CarPart.Name = request.Name != null ? request.Name : CarPart.Name;
            CarPart.Description = request.Description != null ? request.Description : CarPart.Description;
            CarPart.Price = request.Price != null ? request.Price : CarPart.Price;

            var success = context.SaveChanges() > 0;
            if (success)
            {
                return Ok(CarPart);
            }
            
            throw new Exception("Error updating car part");

        }

        //Deletes car part
        [HttpDelete("{id}", Name = "Delete")]
        public ActionResult Delete(Guid id) 
        {
             try
             {
                 var carPart = context.CarParts.Find(id);
                 if (carPart == null)
                     {
                        return NotFound();
                     }

               context.CarParts.Remove(carPart);
                 var success = context.SaveChanges() > 0;

                   if (success)
                    {
                       return NoContent();
                    }

                      throw new Exception("Error deleting car part");
            }
            catch (Exception ex)
            {
            // Log the exception
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Internal server error");
             }
        }
        
    }
}
