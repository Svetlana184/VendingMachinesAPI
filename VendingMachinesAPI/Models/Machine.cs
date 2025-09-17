using System;
using System.Collections.Generic;

namespace VendingMachinesAPI;

public partial class Machine
{
    public int IdMachine { get; set; }

    public string Address { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly DateInstallation { get; set; }

    public DateOnly DateOfLastService { get; set; }

    public decimal? TotalIncome { get; set; }

    public int IdCompany { get; set; }

    public string? OperatingMode { get; set; }

    public string? CommodityMatrix { get; set; }

    public int? Client { get; set; }

    public int? Operator { get; set; }

    public string? ServiceCard { get; set; }

    public string? IdKitOnline { get; set; }

    public int? Manufacturer { get; set; }

    public int? ManufacturerSlave { get; set; }

    public string? Place { get; set; }

    public TimeOnly? WorkingHourStart { get; set; }

    public TimeOnly? WorkingHourEnd { get; set; }

    public string? NameMachine { get; set; }

    public string? CriticalValues { get; set; }

    public int? Manager { get; set; }

    public string? CollectionCard { get; set; }

    public string? LoadingCard { get; set; }

    public string? PriorityService { get; set; }

    public string? Modem { get; set; }

    public int? Engineer { get; set; }

    public string? NotificationTemplate { get; set; }

    public float? Timezone { get; set; }

    public string? Coordinates { get; set; }

    public string? ModelSlave { get; set; }

    public decimal? CostRentMonth { get; set; }

    public decimal? CostRentYear { get; set; }

    public string? RentStatus { get; set; }

    public int? PaybackPeriod { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual User? EngineerNavigation { get; set; }

    public virtual Company IdCompanyNavigation { get; set; } = null!;

    public virtual User? ManagerNavigation { get; set; }

    public virtual User? OperatorNavigation { get; set; }

    public virtual ICollection<PaymentSystem> PaymentSystems { get; set; } = new List<PaymentSystem>();

    public virtual ICollection<ProductInMachine> ProductInMachines { get; set; } = new List<ProductInMachine>();

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual ICollection<Service> Services { get; set; } = new List<Service>();
}
