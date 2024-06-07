//using Microsoft.AspNetCore.Mvc;
//using PoolSystemAPIWebApp.Model;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;

//namespace PoolSystemAPIWebApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class AdministratorsController : ControllerBase
//    {
//        private readonly PoolContext _context;

//        public AdministratorsController(PoolContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Administrators
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Administrator>>> GetAdministrators()
//        {
//            return await _context.Administrators.ToListAsync();
//        }

//        // GET: api/Administrators/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Administrator>> GetAdministrator(int id)
//        {
//            var administrator = await _context.Administrators.FindAsync(id);

//            if (administrator == null)
//            {
//                return NotFound();
//            }

//            return administrator;
//        }

//        // POST: api/Administrators
//        [HttpPost]
//        public async Task<ActionResult<Administrator>> CreateAdministrator(Administrator administrator)
//        {
//            _context.Administrators.Add(administrator);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetAdministrator), new { id = administrator.AdminId }, administrator);
//        }

//        // PUT: api/Administrators/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> EditAdministrator(int id, Administrator administrator)
//        {
//            if (id != administrator.AdminId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(administrator).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AdministratorExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // DELETE: api/Administrators/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAdministrator(int id)
//        {
//            var administrator = await _context.Administrators.FindAsync(id);
//            if (administrator == null)
//            {
//                return NotFound();
//            }

//            _context.Administrators.Remove(administrator);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool AdministratorExists(int id)
//        {
//            return _context.Administrators.Any(e => e.AdminId == id);
//        }
//    }
//}
