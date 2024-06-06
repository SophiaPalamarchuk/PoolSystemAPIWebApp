using System;
using System.Collections.Generic;

namespace PoolSystemAPIWebApp.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string ClassName { get; set; } = null!;

    public string? Description { get; set; }

    public int? ScheduleId { get; set; }

    public virtual Schedule? Schedule { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
