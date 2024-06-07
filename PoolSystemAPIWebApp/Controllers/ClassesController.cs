//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using PoolSystemAPIWebApp.Model;
//using Microsoft.AspNetCore.Http;

//namespace PoolSystemAPIWebApp.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class ClassesController : Controller
//    {
//        private readonly PoolContext _context;

//        public ClassesController(PoolContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Classes
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
//        {
//            var poolContext = _context.Classes.Include(c => c.Schedule);
//            return await poolContext.ToListAsync();
//        }

//        // GET: api/Classes/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Class>> GetClass(int id)
//        {
//            var @class = await _context.Classes
//                .Include(c => c.Schedule)
//                .FirstOrDefaultAsync(m => m.ClassId == id);

//            if (@class == null)
//            {
//                return NotFound();
//            }

//            return @class;
//        }

//        // POST: api/Classes
//        [HttpPost]
//        public async Task<ActionResult<Class>> CreateClass([Bind("ClassId,ClassName,Description,ScheduleId")] Class @class)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(@class);
//                await _context.SaveChangesAsync();
//                return CreatedAtAction(nameof(GetClass), new { id = @class.ClassId }, @class);
//            }
//            return BadRequest(ModelState);
//        }

//        // PUT: api/Classes/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> EditClass(int id, [Bind("ClassId,ClassName,Description,ScheduleId")] Class @class)
//        {
//            if (id != @class.ClassId)
//            {
//                return BadRequest();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(@class);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ClassExists(@class.ClassId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return NoContent();
//            }
//            return BadRequest(ModelState);
//        }

//        // DELETE: api/Classes/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteClass(int id)
//        {
//            var @class = await _context.Classes.FindAsync(id);
//            if (@class == null)
//            {
//                return NotFound();
//            }

//            _context.Classes.Remove(@class);
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }

//        private bool ClassExists(int id)
//        {
//            return _context.Classes.Any(e => e.ClassId == id);
//        }
//    }
//}
