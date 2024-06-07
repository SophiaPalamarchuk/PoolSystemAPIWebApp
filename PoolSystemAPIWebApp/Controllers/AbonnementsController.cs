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
//    public class AbonnementsController : ControllerBase
//    {
//        private readonly PoolContext _context;

//        public AbonnementsController(PoolContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Abonnements
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Abonnement>>> GetAbonnements()
//        {
//            return await _context.Abonnements.ToListAsync();
//        }

//        // GET: api/Abonnements/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Abonnement>> GetAbonnement(int id)
//        {
//            var abonnement = await _context.Abonnements.FindAsync(id);

//            if (abonnement == null)
//            {
//                return NotFound();
//            }

//            return abonnement;
//        }

//        // POST: api/Abonnements
//        [HttpPost]
//        public async Task<ActionResult<Abonnement>> CreateAbonnement(Abonnement abonnement)
//        {
//            _context.Abonnements.Add(abonnement);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction(nameof(GetAbonnement), new { id = abonnement.AbonnementId }, abonnement);
//        }

//        // PUT: api/Abonnements/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> EditAbonnement(int id, Abonnement abonnement)
//        {
//            if (id != abonnement.AbonnementId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(abonnement).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!AbonnementExists(id))
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

//        // DELETE: api/Abonnements/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteAbonnement(int id)
//        {
//            var abonnement = await _context.Abonnements.FindAsync(id);
//            if (abonnement == null)
//            {
//                return NotFound();
//            }

//            _context.Abonnements.Remove(abonnement);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool AbonnementExists(int id)
//        {
//            return _context.Abonnements.Any(e => e.AbonnementId == id);
//        }
//    }
//}
