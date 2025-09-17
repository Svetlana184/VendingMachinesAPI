using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VendingMachinesAPI;

public partial class VendingMachinesContext : DbContext
{
    public VendingMachinesContext()
    {
        Database.EnsureCreated();
    }

    public VendingMachinesContext(DbContextOptions<VendingMachinesContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Machine> Machines { get; set; }

    public virtual DbSet<PaymentSystem> PaymentSystems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInMachine> ProductInMachines { get; set; }

    public virtual DbSet<Rent> Rents { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=GOBLINSCOMP3;Initial Catalog=VendingMachines;User ID=sa;Password=1234;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany);

            entity.ToTable("Company");

            entity.Property(e => e.Address).HasColumnType("ntext");
            entity.Property(e => e.Contacts).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.NameCompany).HasMaxLength(200);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.IdContract);

            entity.ToTable("Contract");

            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Machine");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_User");
        });

        modelBuilder.Entity<Machine>(entity =>
        {
            entity.HasKey(e => e.IdMachine);

            entity.ToTable("Machine");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.CollectionCard).HasMaxLength(100);
            entity.Property(e => e.CommodityMatrix).HasMaxLength(100);
            entity.Property(e => e.Coordinates).HasMaxLength(500);
            entity.Property(e => e.CostRentMonth).HasColumnType("money");
            entity.Property(e => e.CostRentYear).HasColumnType("money");
            entity.Property(e => e.CriticalValues).HasMaxLength(50);
            entity.Property(e => e.IdKitOnline).HasMaxLength(200);
            entity.Property(e => e.LoadingCard).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.ModelSlave).HasMaxLength(50);
            entity.Property(e => e.Modem).HasMaxLength(200);
            entity.Property(e => e.NameMachine).HasMaxLength(50);
            entity.Property(e => e.NotificationTemplate).HasMaxLength(50);
            entity.Property(e => e.OperatingMode).HasMaxLength(50);
            entity.Property(e => e.Place).HasMaxLength(500);
            entity.Property(e => e.PriorityService).HasMaxLength(50);
            entity.Property(e => e.RentStatus).HasMaxLength(50);
            entity.Property(e => e.ServiceCard).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalIncome).HasColumnType("money");

            entity.HasOne(d => d.EngineerNavigation).WithMany(p => p.MachineEngineerNavigations)
                .HasForeignKey(d => d.Engineer)
                .HasConstraintName("FK_Machine_User2");

            entity.HasOne(d => d.IdCompanyNavigation).WithMany(p => p.Machines)
                .HasForeignKey(d => d.IdCompany)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Machine_Company");

            entity.HasOne(d => d.ManagerNavigation).WithMany(p => p.MachineManagerNavigations)
                .HasForeignKey(d => d.Manager)
                .HasConstraintName("FK_Machine_User1");

            entity.HasOne(d => d.OperatorNavigation).WithMany(p => p.MachineOperatorNavigations)
                .HasForeignKey(d => d.Operator)
                .HasConstraintName("FK_Machine_User");
        });

        modelBuilder.Entity<PaymentSystem>(entity =>
        {
            entity.HasKey(e => e.IdPaymentSystems);

            entity.ToTable("PaymentSystem");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.PaymentSystems)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentSystem_Machine");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("Product");

            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description).HasColumnType("ntext");
            entity.Property(e => e.NameProduct).HasMaxLength(300);
            entity.Property(e => e.SalesPropensity).HasMaxLength(500);
        });

        modelBuilder.Entity<ProductInMachine>(entity =>
        {
            entity.HasKey(e => e.IdProductInMachine);

            entity.ToTable("ProductInMachine");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.ProductInMachines)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInMachine_Machine");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.ProductInMachines)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductInMachine_Product");
        });

        modelBuilder.Entity<Rent>(entity =>
        {
            entity.HasKey(e => e.IdRent);

            entity.ToTable("Rent");

            entity.Property(e => e.ConductingMethod).HasMaxLength(200);
            entity.Property(e => e.IdMachine).HasColumnName("idMachine");
            entity.Property(e => e.Insurance).HasMaxLength(10);

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Rents)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rent_Machine");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Rents)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rent_User");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdSale);

            entity.ToTable("Sale");

            entity.Property(e => e.DateOfSale).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Sum).HasColumnType("money");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Machine");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sale_Product");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService);

            entity.ToTable("Service");

            entity.Property(e => e.Description).HasMaxLength(300);
            entity.Property(e => e.IdMachine).HasColumnName("idMachine");
            entity.Property(e => e.Problems).HasColumnType("ntext");

            entity.HasOne(d => d.IdMachineNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.IdMachine)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_Machine");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Services)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Service_User");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.FirstName).HasMaxLength(70);
            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Photo).HasColumnType("image");
            entity.Property(e => e.Role).HasMaxLength(100);
            entity.Property(e => e.SecondName).HasMaxLength(100);
            entity.Property(e => e.Surname).HasMaxLength(70);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
