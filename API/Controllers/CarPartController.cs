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

        // <summary>
        // 
        // </summary>
        // <param name="id"></param>
        // <returns></returns> <summary>
        // 
        // </summary>
        // <param name="id"></param>
        // <returns></returns>
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

        // <summary>
        // Creates a new Car Part
        // </summary>
        // <param name="request"></param>
        // <returns></returns>
        // <exception cref="Exception"></exception> <summary>
        // 
        // </summary>
        // <param name="request"></param>
        // <returns></returns>
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

    }
}
