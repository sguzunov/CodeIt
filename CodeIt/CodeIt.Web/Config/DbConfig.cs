using System.Data.Entity;

using CodeIt.Data;
using CodeIt.Data.Migrations;

namespace CodeIt.Web.Config
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer<CodeItDbContext>(new MigrateDatabaseToLatestVersion<CodeItDbContext, Configuration>());
            CodeItDbContext.Create().Database.Initialize(true);
        }
    }
}