using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class Rent
{
    public int IdRent { get; set; }

    public int IdMachine { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateEnd { get; set; }

    public string ConductingMethod { get; set; } = null!;

    public string Insurance { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual Machine IdMachineNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
