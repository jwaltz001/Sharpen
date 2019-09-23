using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharpen.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sharpen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private readonly ApiContext _context;

        public MonsterController(ApiContext context)
        {
            _context = context;

            if (_context.Monsters.Count() == 0)
            {
                _context.Monsters.Add(new Monster { Name = "Monster 1" });
                _context.SaveChanges();
            }
        }

        //GET api/Monster
        public async Task<ActionResult<IEnumerable<Monster>>> GetMonsters()
        {
            return await _context.Monsters.ToListAsync();
        }

        //GET api/Monster/:id
		[HttpGet("{id}")]
        public async Task<ActionResult<Monster>> GetMonster(int id)
        {
            var monster = await _context.Monsters.FindAsync(id);
            if (monster == null)
            {
                return NotFound();
            }

            return monster;
        }

        // POST: api/Monster
		[HttpPost]
		public async Task<ActionResult<Monster>> PostMonster(Monster monster)
		{
			_context.Monsters.Add(monster);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetMonster), new { id = monster.Id }, monster);
		}

		// PUT: api/Todo/:id
		[HttpPut("{id}")]
		public async Task<IActionResult> PutMonster(int id, Monster monster)
		{
			if (id != monster.Id)
			{
				return BadRequest();
			}

			_context.Entry(monster).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

        // DELETE: api/Todo/:id
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteMonster(int id)
		{
			var monster = await _context.Monsters.FindAsync(id);

			if (monster == null)
			{
				return NotFound();
			}

			_context.Monsters.Remove(monster);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
