using EFCore_Multi_BD.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Multi_BD.Repository.Configuration.NpgPost
{
    public class StationNpgSqlConfiguration : IEntityTypeConfiguration<Station>
    {
        public void Configure(EntityTypeBuilder<Station> builder)
        {
            ConfigNameTable(builder);
            ConfigPrimaryKey(builder);
            ConfigProperties(builder);
            ConfigIdentity(builder);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigIdentity(EntityTypeBuilder<Station> builder)
        {
            builder.Property(a => a.Id).UseIdentityAlwaysColumn().ValueGeneratedOnAdd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigProperties(EntityTypeBuilder<Station> builder)
        {
            builder.Property(con => con.Id).HasColumnName("id");
            builder.Property(con => con.Name).HasColumnName("nome");
            builder.Property(con => con.Address).HasColumnName("endereco");
            builder.Property(con => con.Phone).HasColumnName("telefone");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigPrimaryKey(EntityTypeBuilder<Station> builder)
        {
            builder.HasKey(u => u.Id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        private void ConfigNameTable(EntityTypeBuilder<Station> builder)
        {
            builder.ToTable("station", "meuschema");
        }
    }
}