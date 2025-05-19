using System;
using System.Collections.Generic;

namespace Maintenance;

public partial class SuppRegister
{
    public int Id { get; set; }

    public int TruckId { get; set; }

    public DateOnly Date { get; set; }

    public string? Description { get; set; }

    public virtual Truck Truck { get; set; } = null!;
}
