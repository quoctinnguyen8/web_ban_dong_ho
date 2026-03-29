using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Models;

namespace WebBanDongHo.Web.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppWatch> AppWatches => Set<AppWatch>();
    public DbSet<AppAccount> AppAccounts => Set<AppAccount>();
    public DbSet<AppOrder> AppOrders => Set<AppOrder>();
    public DbSet<AppOrderItem> AppOrderItems => Set<AppOrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var seededAt = new DateTime(2026, 3, 29, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<AppWatch>(entity =>
        {
            entity.ToTable("AppWatch");

            entity.Property(x => x.Brand)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.Sku)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasIndex(x => x.Sku)
                .IsUnique();

            entity.Property(x => x.ShortDescription)
                .HasMaxLength(400);

            entity.Property(x => x.LongDescription)
                .HasMaxLength(2000);

            entity.Property(x => x.MovementType)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.CaseSizeMm)
                .HasPrecision(5, 2);

            entity.Property(x => x.ImageUrl)
                .HasMaxLength(500);

            entity.Property(x => x.Price)
                .HasPrecision(18, 2);

            entity.HasData(
                new AppWatch
                {
                    Id = 1,
                    Brand = "Orient",
                    Name = "Orient Bambino Gen 2",
                    Sku = "ORI-BAM-002",
                    ShortDescription = "Mẫu dress watch cổ điển, kính cong và máy cơ tự động.",
                    LongDescription = "Orient Bambino Gen 2 mang phong cách thanh lịch cổ điển, phù hợp cho môi trường công sở và các dịp trang trọng.",
                    MovementType = "Automatic",
                    CaseSizeMm = 40.50m,
                    WaterResistanceM = 30,
                    ImageUrl = "https://images.unsplash.com/photo-1524592094714-0f0654e20314?auto=format&fit=crop&w=1200&q=80",
                    Price = 5600000m,
                    Stock = 8,
                    CreatedDate = seededAt,
                    LastModifiedDate = seededAt,
                    DeletedDate = null,
                    CreatedBy = 1,
                    ModifiedBy = 1
                },
                new AppWatch
                {
                    Id = 2,
                    Brand = "Tissot",
                    Name = "Tissot PRX Powermatic 80",
                    Sku = "TIS-PRX-080",
                    ShortDescription = "Thiết kế integrated bracelet hiện đại, dự trữ cót lên tới 80 giờ.",
                    LongDescription = "PRX Powermatic 80 nổi bật với thiết kế thể thao sang trọng và bộ máy mạnh mẽ có khả năng trữ cót dài.",
                    MovementType = "Automatic",
                    CaseSizeMm = 40.00m,
                    WaterResistanceM = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1542496658-e33a6d0d50f6?auto=format&fit=crop&w=1200&q=80",
                    Price = 18500000m,
                    Stock = 5,
                    CreatedDate = seededAt,
                    LastModifiedDate = seededAt,
                    DeletedDate = null,
                    CreatedBy = 1,
                    ModifiedBy = 1
                },
                new AppWatch
                {
                    Id = 3,
                    Brand = "Seiko",
                    Name = "Seiko 5 Sports SRPD55",
                    Sku = "SEI-5S-SRPD55",
                    ShortDescription = "Dòng đồng hồ cơ bền bỉ, phong cách thể thao đa dụng.",
                    LongDescription = "Seiko 5 Sports SRPD55 là lựa chọn linh hoạt cho sử dụng hàng ngày với thiết kế khỏe khoắn và độ bền cao.",
                    MovementType = "Automatic",
                    CaseSizeMm = 42.50m,
                    WaterResistanceM = 100,
                    ImageUrl = "https://images.unsplash.com/photo-1617625802912-cde586faf331?auto=format&fit=crop&w=1200&q=80",
                    Price = 7900000m,
                    Stock = 10,
                    CreatedDate = seededAt,
                    LastModifiedDate = seededAt,
                    DeletedDate = null,
                    CreatedBy = 1,
                    ModifiedBy = 1
                });
        });

        modelBuilder.Entity<AppAccount>(entity =>
        {
            entity.ToTable("AppAccount");

            entity.Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasIndex(x => x.Username)
                .IsUnique();

            entity.Property(x => x.PasswordHash)
                .HasMaxLength(500)
                .IsRequired();

            entity.Property(x => x.FullName)
                .HasMaxLength(120)
                .IsRequired();
        });

        modelBuilder.Entity<AppOrder>(entity =>
        {
            entity.ToTable("AppOrder");

            entity.Property(x => x.OrderCode)
                .HasMaxLength(30)
                .IsRequired();

            entity.HasIndex(x => x.OrderCode)
                .IsUnique();

            entity.Property(x => x.CustomerName)
                .HasMaxLength(120)
                .IsRequired();

            entity.Property(x => x.CustomerPhone)
                .HasMaxLength(20)
                .IsRequired();

            entity.Property(x => x.CustomerAddress)
                .HasMaxLength(250)
                .IsRequired();

            entity.Property(x => x.Note)
                .HasMaxLength(500);

            entity.Property(x => x.Status)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(x => x.TotalAmount)
                .HasPrecision(18, 2);
        });

        modelBuilder.Entity<AppOrderItem>(entity =>
        {
            entity.ToTable("AppOrderItem");

            entity.Property(x => x.WatchName)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(x => x.WatchSku)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.UnitPrice)
                .HasPrecision(18, 2);

            entity.Property(x => x.LineTotal)
                .HasPrecision(18, 2);

            entity.HasOne(x => x.Order)
                .WithMany(x => x.OrderItems)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }
}
