using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakasOne.DataConnection;
using ZakasOne.Model;

namespace ZakasOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZakaslarController : ControllerBase
    {
        private readonly ZakasData _context;
        public ZakaslarController(ZakasData contect)
        {
            _context = contect;
        }
        [HttpPost]
        public async Task<IActionResult> CreateZakas([FromBody] Zakas zakas)
        {
            zakas.Berilgan_vaqt = DateTime.UtcNow;
            _context.Zakas.Add(zakas);
            await _context.SaveChangesAsync();
            return Ok(zakas);
        }
        [HttpGet]
        public async Task<IActionResult> GetZakas()
        {
            var zakas = await _context.Zakas.ToListAsync();
            return Ok(zakas);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteZakas(int id)
        {
            var malumot = await _context.Zakas.FindAsync(id);
            if (malumot == null)
            {
                return NotFound();
            }
             _context.Zakas.Remove(malumot);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
