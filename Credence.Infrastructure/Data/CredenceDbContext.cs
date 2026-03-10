using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Credence.Domain.BusinessContext.Entities;
using Credence.Domain.CompanyContext.Entities;
using Credence.Domain.ProfileContext.Entities;
using Credence.Domain.UserContext.Entities;
using Credence.Domain.AuthContext.Entities;
// using System.Diagnostics;

namespace Credence.Infrastructure.Data;

public class CredenceDbContext(DbContextOptions<CredenceDbContext> options) : IdentityDbContext
                                                                                <User,
                                                                                Role, Guid,
                                                                                IdentityUserClaim<Guid>,
                                                                                UserRole,
                                                                                IdentityUserLogin<Guid>,
                                                                                IdentityRoleClaim<Guid>,
                                                                                IdentityUserToken<Guid>>
                                                                                (options)
{
    // public DbSet<Category> Categories { get; set; } = null!;
    // public DbSet<Transaction> Transactions { get; set; } = null!;
    public DbSet<Business> Businesses { get; set; } = null!;
    public DbSet<Company> Companies { get; set; } = null!;
    public DbSet<Contact> Contacts { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        // builder.Ignore<Notification>();
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    // public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    // {
    //     Console.WriteLine("SaveChanges foi chamado!");
    //     var test = new StackTrace().ToString();
    //     Console.WriteLine(new StackTrace().ToString());
    //     return base.SaveChangesAsync(cancellationToken);
    // }
}