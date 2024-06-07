using Microsoft.AspNetCore.Mvc;
using PoolSystemAPIWebApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PoolSystemAPIWebApp.DTOs;
using PoolSystemAPIWebApp.Mappers;

namespace PoolSystemAPIWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchedulesController : ControllerBase
    {
        private readonly PoolContext _context;

        public SchedulesController(PoolContext context)
        {
            _context = context;
        }

        // GET: api/Schedules
        [HttpGet]
        public async Task<IActionResult> GetSchedules()
        {
            return Ok(await _context.Schedules.Select(sc => sc.ToScheduleDto()).ToListAsync());
        }

        // GET: api/Schedules/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);

            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule.ToScheduleDto());
        }

        // POST: api/Schedules
        [HttpPost]
        public async Task<IActionResult> CreateSchedule(SchedulePostRequestDto scheduleDto)
        {
            var schedule = scheduleDto.ToSchedule();
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchedule), new { id = schedule.ScheduleId }, scheduleDto);
        }

        // PUT: api/Schedules/5
        [HttpPut("{id}")]
        public async Task<IActionResult> EditSchedule(int id, ScheduleDto schedule)
        {
            if (id != schedule.ScheduleId)
            {
                return BadRequest();
            }

            try
            {
                var scheduleModel = await _context.Schedules.FindAsync(schedule.ScheduleId);
                if(scheduleModel == null)
                {
                    return NotFound();
                }
                scheduleModel.StartTime = schedule.StartTime;
                scheduleModel.EndTime = schedule.EndTime;
                scheduleModel.DayOfWeek = schedule.DayOfWeek;
                _context.Schedules.Update(scheduleModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
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

        // DELETE: api/Schedules/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return Ok(NoContent());
        }

        private bool ScheduleExists(int id)
        {
            return _context.Schedules.Any(e => e.ScheduleId == id);
        }
    }
}
