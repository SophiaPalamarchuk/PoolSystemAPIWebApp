using System;
using System.Collections.Generic;

namespace PoolSystemAPIWebApp.Model;

public partial class Administrator
{
    public int AdminId { get; set; }

    public int? UserId { get; set; }

    public string Role { get; set; } = null!;
}
