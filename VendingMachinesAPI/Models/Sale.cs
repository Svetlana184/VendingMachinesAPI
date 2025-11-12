using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VendingMachinesAPI;

public partial class Sale
{
    public int IdSale { get; set; }

    public int IdMachine { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal Sum { get; set; }

    public DateTime DateOfSale { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string? Status { get; set; }
    [JsonIgnore]
    public virtual Machine IdMachineNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Product IdProductNavigation { get; set; } = null!;
}
