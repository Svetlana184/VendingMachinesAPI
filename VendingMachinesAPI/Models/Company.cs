using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class Company
{
    public int IdCompany { get; set; }

    public int? IdParentCompany { get; set; }

    public string Contacts { get; set; } = null!;

    public string NameCompany { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();
}
