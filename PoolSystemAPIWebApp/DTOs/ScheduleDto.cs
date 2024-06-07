using System;
using System.Collections.Generic;

using PoolSystemAPIWebApp.Model;

namespace PoolSystemAPIWebApp.DTOs
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }

        public string DayOfWeek { get; set; } = null!;

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }
    }
}