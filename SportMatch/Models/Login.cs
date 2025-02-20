using System;
using System.Collections.Generic;

namespace SportMatch.Models;

public partial class Login
{
    public int Id { get; set; }

    public string Account { get; set; } = null!;

    public string Password { get; set; } = null!;
}
