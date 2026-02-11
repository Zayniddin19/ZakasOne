using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZakasOne.DataConnection;
using ZakasOne.Model;

namespace ZakasOne.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Controller : ControllerBase
    {
        private readonly ZakasData _context;
        public Controller(ZakasData contect)
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
    }
}
