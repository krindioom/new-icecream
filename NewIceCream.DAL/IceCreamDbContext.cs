using Microsoft.EntityFrameworkCore;
using NewIceCream.Domain.Models;

namespace NewIceCream.DAL;

public partial class IcecreamDbContext : DbContext
{
    public IcecreamDbContext()
    {
    }

    public IcecreamDbContext(DbContextOptions<IcecreamDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartIcecream> CartIcecreams { get; set; }

    public virtual DbSet<Cone> Cones { get; set; }

    public virtual DbSet<Flavor> Flavors { get; set; }

    public virtual DbSet<FlavorIcecream> FlavorIcecreams { get; set; }

    public virtual DbSet<Icecream> Icecreams { get; set; }

    public virtual DbSet<IcecreamCategory> IcecreamCategories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUser__3214EC07F47C1D38");

            entity.ToTable("AppUser");

            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(30);
            entity.Property(e => e.UserPassword).HasMaxLength(50);
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cart__3214EC077B8D6B42");

            entity.ToTable("Cart");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Carts)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cart__IdUser__29572725");
        });

        modelBuilder.Entity<CartIcecream>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CartIcec__3214EC07A3A4DD89");

            entity.ToTable("CartIcecream");

            entity.HasOne(d => d.IdCartNavigation).WithMany(p => p.CartIcecreams)
                .HasForeignKey(d => d.IdCart)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartIcecr__IdCar__2C3393D0");

            entity.HasOne(d => d.IdIcecreamNavigation).WithMany(p => p.CartIcecreams)
                .HasForeignKey(d => d.IdIcecream)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartIcecr__IdIce__2D27B809");
        });

        modelBuilder.Entity<Cone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cone__3214EC07C8C8856E");

            entity.ToTable("Cone");

            entity.Property(e => e.ConeType).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Flavor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Flavor__3214EC078D9E9573");

            entity.ToTable("Flavor");

            entity.Property(e => e.FlavorTaste).HasMaxLength(20);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<FlavorIcecream>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FlavorIc__3214EC07991B3160");

            entity.ToTable("FlavorIcecream");

            entity.HasOne(d => d.IdFlavorNavigation).WithMany(p => p.FlavorIcecreams)
                .HasForeignKey(d => d.IdFlavor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FlavorIce__IdFla__25869641");

            entity.HasOne(d => d.IdIcecreamNavigation).WithMany(p => p.FlavorIcecreams)
                .HasForeignKey(d => d.IdIcecream)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FlavorIce__IdIce__267ABA7A");
        });

        modelBuilder.Entity<Icecream>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Icecream__3214EC07F72A56F9");

            entity.ToTable("Icecream");

            entity.Property(e => e.Price).HasColumnType("money");

            entity.HasOne(d => d.IdConeNavigation).WithMany(p => p.Icecreams)
                .HasForeignKey(d => d.IdCone)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Icecream__IdCone__21B6055D");

            entity.HasOne(d => d.IdIcecreamCategoryNavigation).WithMany(p => p.Icecreams)
                .HasForeignKey(d => d.IdIcecreamCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Icecream__IdIcec__22AA2996");
        });

        modelBuilder.Entity<IcecreamCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Icecream__3214EC0781AB5DF2");

            entity.ToTable("IcecreamCategory");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
