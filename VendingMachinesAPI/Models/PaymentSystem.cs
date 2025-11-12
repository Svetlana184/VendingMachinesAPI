using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VendingMachinesAPI;

public partial class PaymentSystem
{
    public int IdPaymentSystems { get; set; }

    public string Type { get; set; } = null!;

    public int IdMachine { get; set; }
    [JsonIgnore]
    public virtual Machine IdMachineNavigation { get; set; } = null!;
}
