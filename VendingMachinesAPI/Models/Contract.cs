using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VendingMachinesAPI;

public partial class Contract
{
    public int IdContract { get; set; }

    public DateOnly? DateOfSigning { get; set; }

    public DateOnly? ValidityPeriod { get; set; }

    public string Status { get; set; } = null!;

    public int IdUser { get; set; }

    public int IdMachine { get; set; }

    [JsonIgnore]
    public virtual Machine IdMachineNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual User IdUserNavigation { get; set; } = null!;
}
