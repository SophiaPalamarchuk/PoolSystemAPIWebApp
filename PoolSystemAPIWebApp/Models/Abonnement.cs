using System;
using System.Collections.Generic;

namespace PoolSystemAPIWebApp.Models;

public partial class Abonnement
{
    public int AbonnementId { get; set; }

    public int? UserId { get; set; }

    public string Type { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual User? User { get; set; }
}
