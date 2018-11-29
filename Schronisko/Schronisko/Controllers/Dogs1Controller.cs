using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Schronisko;

namespace Schronisko.Controllers
{
    [Route("api/doge")]
    [ApiController]
    public class Dogs1Controller : ControllerBase
    {
        private readonly DogeContext _context;

        public Dogs1Controller(DogeContext context)
        {
            _context = context;
        }

        // GET: api/Dogs1
        [HttpGet]
        public IEnumerable<Dog> GetDogs()
        {
            return _context.Dogs;
        }

        // GET: api/Dogs1/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dog = await _context.Dogs.FindAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // PUT: api/Dogs1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog([FromRoute] int id, [FromBody] Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dog.DogId)
            {
                return BadRequest();
            }

            _context.Entry(dog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dogs1
        [HttpPost]
        public async Task<IActionResult> PostDog([FromBody] Dog dog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDog", new { id = dog.DogId }, dog);
        }

        // DELETE: api/Dogs1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null)
            {
                return NotFound();
            }

            _context.Dogs.Remove(dog);
            await _context.SaveChangesAsync();

            return Ok(dog);
        }

        private bool DogExists(int id)
        {
            return _context.Dogs.Any(e => e.DogId == id);
        }
    }
}