﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherFCProject.Models;

namespace WeatherFCProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        private readonly WFCastContext _context;

        public WeathersController(WFCastContext context)
        {
            _context = context;
        }

        // GET: api/Weathers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeathers()
        {
            return await _context.Weathers.ToListAsync();
        }

        // GET: api/Weathers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(int id)
        {
            var weather = await _context.Weathers.FindAsync(id);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weathers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, Weather weather)
        {
            if (id != weather.ID)
            {
                return BadRequest();
            }

            _context.Entry(weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
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

        // POST: api/Weathers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
            _context.Weathers.Add(weather);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeather", new { id = weather.ID }, weather);
        }

        // DELETE: api/Weathers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            var weather = await _context.Weathers.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            _context.Weathers.Remove(weather);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherExists(int id)
        {
            return _context.Weathers.Any(e => e.ID == id);
        }
    }
}
