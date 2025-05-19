using System;
using System.Collections.Generic;

namespace Transport;

public partial class Truck
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public short Year { get; set; }

    public int Mileage { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<SuppRegister> SuppRegisters { get; set; } = new List<SuppRegister>();

    public virtual ICollection<TravelRegister> TravelRegisters { get; set; } = new List<TravelRegister>();
}
