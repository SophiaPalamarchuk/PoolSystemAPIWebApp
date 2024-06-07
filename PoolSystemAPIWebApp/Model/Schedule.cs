using System;
using System.Collections.Generic;

namespace PoolSystemAPIWebApp.Model;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public string DayOfWeek { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
