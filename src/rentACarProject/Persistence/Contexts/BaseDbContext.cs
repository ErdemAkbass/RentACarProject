using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.EntityConfigurations;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Model> Models { get; set; }
    public DbSet<Fuel> Fuels { get; set; }
    public DbSet<Transmission> Transmissions { get; set; }
    public DbSet<Color> Colors { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.ApplyConfiguration(new EmailAuthenticatorConfiguration());
        modelBuilder.ApplyConfiguration(new OperationClaimConfiguration());
        modelBuilder.ApplyConfiguration(new OtpAuthenticatorConfiguration());
        modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserOperationClaimConfiguration());
        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new BrandConfiguration());
        modelBuilder.ApplyConfiguration(new ModelConfiguration());
        modelBuilder.ApplyConfiguration(new FuelConfiguration());
        modelBuilder.ApplyConfiguration(new TransmissionConfiguration());
        modelBuilder.ApplyConfiguration(new ColorConfiguration());
    }
}
