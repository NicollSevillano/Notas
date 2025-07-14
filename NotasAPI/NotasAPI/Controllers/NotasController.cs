using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotasAPI.Data;
using NotasAPI.Models;

namespace NotasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NotasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nota>>> GetNota()
        {
            return await _context.Notes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Nota>> GetNota(int id)
        {
            var nota = await _context.Notes.FindAsync(id);
            if (nota == null) return NotFound();
            return nota;
        }

        [HttpPost]
        public async Task<ActionResult<Nota>> CreateNote([FromBody] Nota note)
        {
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetNota), new { id = note.Id }, note);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNote(int id, [FromBody] Nota note)
        {
            if (id != note.Id) return BadRequest();

            _context.Entry(note).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var nota = await _context.Notes.FindAsync(id);
            if (nota == null) return NotFound();

            _context.Notes.Remove(nota);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
