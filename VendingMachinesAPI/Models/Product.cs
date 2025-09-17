using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Cost { get; set; }

    public int MinimumStock { get; set; }

    public string? SalesPropensity { get; set; }

    public virtual ICollection<ProductInMachine> ProductInMachines { get; set; } = new List<ProductInMachine>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
