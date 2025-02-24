﻿using System;
using System.Collections.Generic;

namespace SportMatch.Models;

public partial class Sport
{
    public int SportId { get; set; }

    public string SportName { get; set; } = null!;

    public int SportMax { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();

    public virtual ICollection<SportsVenue> SportsVenues { get; set; } = new List<SportsVenue>();

    public virtual ICollection<TeamMemberMapping> TeamMemberMappings { get; set; } = new List<TeamMemberMapping>();

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();

    public virtual ICollection<UserDatum> UserData { get; set; } = new List<UserDatum>();
}
