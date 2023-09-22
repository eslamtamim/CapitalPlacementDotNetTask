using CapitalPlacementDotNetTask.Models;
using Microsoft.EntityFrameworkCore;

namespace CapitalPlacementDotNetTask.Data;

public class CosmosDataBaseContext : DbContext
{

    public CosmosDataBaseContext(DbContextOptions<CosmosDataBaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<ProgramModel>().ToContainer("Programs").HasPartitionKey(p => p.Id);
        modelBuilder.Entity<ProgramModel>().OwnsOne(p=> p.ProgramDetails);
        modelBuilder.Entity<ProgramModel>().OwnsOne(p => p.ApplicationForm);
        modelBuilder.Entity<ProgramModel>().OwnsOne(p=>p.WorkFlow);
    }

    public DbSet<ProgramModel> Programs { get; set; }

}
