﻿using System;
using System.Collections.Generic;

namespace PoolSystemAPIWebApp.Model;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Abonnement> Abonnements { get; set; } = new List<Abonnement>();

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();
}
