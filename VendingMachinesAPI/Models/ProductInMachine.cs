using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VendingMachinesAPI;

public partial class ProductInMachine
{
    public int IdProductInMachine { get; set; }

    public int IdProduct { get; set; }

    public int IdMachine { get; set; }

    public int QuantityInStock { get; set; }
    [JsonIgnore]
    public virtual Machine IdMachineNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Product IdProductNavigation { get; set; } = null!;
}
