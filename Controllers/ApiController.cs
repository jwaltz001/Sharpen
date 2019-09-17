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
    public class PlayerController : ControllerBase
    {
        private readonly ApiContext _context;

        public PlayerController(ApiContext context)
        {
            _context = context;

            if (_context.Players.Count() == 0)
            {
                _context.Players.Add(new Player { Name = "Player 1" });
                _context.SaveChanges();
            }
        }

        //GET api/Player
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            return await _context.Players.ToListAsync();
        }

        //GET api/Player/:id
		[HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        // POST: api/Player
		[HttpPost]
		public async Task<ActionResult<Player>> PostPlayer(Player player)
		{
			_context.Players.Add(player);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
		}

		// PUT: api/Todo/:id
		[HttpPut("{id}")]
		public async Task<IActionResult> PutPlayer(int id, Player player)
		{
			if (id != player.Id)
			{
				return BadRequest();
			}

			_context.Entry(player).State = EntityState.Modified;
			await _context.SaveChangesAsync();

			return NoContent();
		}

        // DELETE: api/Todo/:id
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletePlayer(int id)
		{
			var player = await _context.Players.FindAsync(id);

			if (player == null)
			{
				return NotFound();
			}

			_context.Players.Remove(player);
			await _context.SaveChangesAsync();

			return NoContent();
		}
	}
}
