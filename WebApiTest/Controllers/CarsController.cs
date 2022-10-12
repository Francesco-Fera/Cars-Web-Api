using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
        }

        // GET Cars
        [HttpGet]
        public  ActionResult<IEnumerable<Car>> GetCarItems()
        {
            if(_context.CarItems.Count() == 0)
            {
                return NotFound("Non ci sono Cars da mostrare");
            }
            return  _context.CarItems.ToList();
        }



        // GET: Cars/id
        [HttpGet("{id}")]
        public Car GetCar(int id)
        {
            var car =  _context.CarItems.Find(id);

            return car;
        }

        // POST: Cars
        [HttpPost]
        public ActionResult<Car> PostCar(Car car)
        {
            if (CarExists(car.Id))
            {
                return Conflict("Già esiste una Car con questo ID");
            }

            _context.CarItems.Add(car);
            _context.SaveChanges();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: Cars/id
        [HttpDelete("{id}")]
        public IActionResult DeleteCar(int id)
        {
            var car = _context.CarItems.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.CarItems.Remove(car);
            _context.SaveChanges();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.CarItems.Any(e => e.Id == id);
        }
    }
}
