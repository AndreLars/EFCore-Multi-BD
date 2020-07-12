using EFCore_Multi_BD.Entities;
using EFCore_Multi_BD.Repository.Configuration.NpgPost;
using EFCore_Multi_BD.Repository.Configuration.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCore_Multi_BD.Context
{
    public class GasStationContext : DbContext
    {
        private readonly string _databaseDefault;
        public GasStationContext
        (
            DbContextOptions<GasStationContext> options,
            IConfiguration configuration
        ) : base(options)
        {
            _databaseDefault = configuration.GetSection("DefaultDatabase").Value;
        }

        public DbSet<Station> Station { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (_databaseDefault == "Postgress")
                ConfigModelCreatingNpgSql(modelBuilder);
            else
                ConfigModelCreatingSqlServer(modelBuilder);

            base.OnModelCreating(modelBuilder);

        }

        private void ConfigModelCreatingSqlServer(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StationSqlServerConfiguration());
        }

        private void ConfigModelCreatingNpgSql(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("citext")
                        .ApplyConfiguration(new StationNpgSqlConfiguration());
        }
    }
}