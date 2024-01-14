using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using EntityFrameworkCore.EncryptColumn.Extension;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace InntoDB
{
    public class InntoDB : DbContext
    {
        private readonly IEncryptionProvider _provider;
        public InntoDB() : base()
        {
            this._provider = new GenerateEncryptionProvider("example_encrypt_key");
        }
        public InntoDB(string connectionString) : base(GetOptions(connectionString))
        {
            this._provider = new GenerateEncryptionProvider("example_encrypt_key");
        }
        private static DbContextOptions GetOptions(string connectionString)
        {
            if (connectionString == null)
            {
                return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), ConfigurationManager.ConnectionStrings["InntoDB"].ConnectionString).Options;
            }
            else
            {
                return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._provider);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<SectionTemplate> SectionTemplates { get; set; }
        public DbSet<UserSection> UserSections { get; set; }
        public DbSet<UserSectionValue> UserSectionValues { get; set; }
        public DbSet<UserSectionOpen> UserSectionOpens { get; set; }
        public DbSet<UsersPersonalMessage> UsersPersonalMessages { get; set; }
    }
}