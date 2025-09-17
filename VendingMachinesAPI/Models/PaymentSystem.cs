using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class PaymentSystem
{
    public int IdPaymentSystems { get; set; }

    public string Type { get; set; } = null!;

    public int IdMachine { get; set; }

    public virtual Machine IdMachineNavigation { get; set; } = null!;
}
