using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class Service
{
    public int IdService { get; set; }

    public int IdMachine { get; set; }

    public DateOnly DateOfService { get; set; }

    public string Description { get; set; } = null!;

    public string? Problems { get; set; }

    public int IdUser { get; set; }

    public virtual Machine IdMachineNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
