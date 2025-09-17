using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class User
{
    public int IdUser { get; set; }

    public string Surname { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? SecondName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string Role { get; set; } = null!;

    public string? Login { get; set; }

    public string? Password { get; set; }

    public byte[]? Photo { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual ICollection<Machine> MachineEngineerNavigations { get; set; } = new List<Machine>();

    public virtual ICollection<Machine> MachineManagerNavigations { get; set; } = new List<Machine>();

    public virtual ICollection<Machine> MachineOperatorNavigations { get; set; } = new List<Machine>();

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
