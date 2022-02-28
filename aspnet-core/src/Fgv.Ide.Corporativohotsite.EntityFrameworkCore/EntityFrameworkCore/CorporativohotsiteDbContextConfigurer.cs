using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore
{
    public static class CorporativohotsiteDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CorporativohotsiteDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CorporativohotsiteDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }

        public static void Configure(DbContextOptionsBuilder<CorporativohotsiteApiDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CorporativohotsiteApiDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}