using System;
using System.Collections.Generic;
using System.Text;

namespace GatheringTheMagic.Domain.Entities;

public sealed class User : BaseEntity
{
    public string? Email { get; set; }
    public string? Name { get; set; } 
}
