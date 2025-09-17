using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class ProductInMachine
{
    public int IdProductInMachine { get; set; }

    public int IdProduct { get; set; }

    public int IdMachine { get; set; }

    public int QuantityInStock { get; set; }

    public virtual Machine IdMachineNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
