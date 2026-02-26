using System;
using System.Collections.Generic;
using System.Text;

namespace GatheringTheMagic.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateModified { get; set; }
    public DateTimeOffset? DateDeleted { get; set; }
}
