using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebBanDongHo.Web.Models;

namespace WebBanDongHo.Web.Data;

public static class ApplicationDbInitializer
{
    public static async Task SeedAccountsAsync(IServiceProvider services)
    {
        var dbContext = services.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = services.GetRequiredService<IPasswordHasher<AppAccount>>();

        await dbContext.Database.MigrateAsync();

        var existingAdmin = await dbContext.AppAccounts
            .FirstOrDefaultAsync(x => x.Username == "admin" && x.DeletedDate == null);

        if (existingAdmin is not null)
        {
            if (!existingAdmin.IsActive || !existingAdmin.IsAdmin)
            {
                existingAdmin.IsActive = true;
                existingAdmin.IsAdmin = true;
                existingAdmin.LastModifiedDate = DateTime.UtcNow;
                existingAdmin.ModifiedBy = existingAdmin.Id;
                await dbContext.SaveChangesAsync();
            }

            return;
        }

        var now = DateTime.UtcNow;
        var adminAccount = new AppAccount
        {
            Username = "admin",
            FullName = "Quản trị hệ thống",
            IsAdmin = true,
            IsActive = true,
            CreatedDate = now,
            LastModifiedDate = now,
            CreatedBy = 1,
            ModifiedBy = 1
        };

        adminAccount.PasswordHash = passwordHasher.HashPassword(adminAccount, "Admin@123");

        dbContext.AppAccounts.Add(adminAccount);
        await dbContext.SaveChangesAsync();
    }
}
