using System;
using System.Collections.Generic;

namespace Maintenance;

public partial class TravelRegister
{
    public int Id { get; set; }

    public int IdTruck { get; set; }

    public string NameCliente { get; set; } = null!;

    public DateOnly Date { get; set; }

    public string Destination { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual Truck IdTruckNavigation { get; set; } = null!;
}
