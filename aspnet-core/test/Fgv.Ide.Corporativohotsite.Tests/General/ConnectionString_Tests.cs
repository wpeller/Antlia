using System.Data.SqlClient;
using Shouldly;
using Xunit;

namespace Fgv.Ide.Corporativohotsite.Tests.General
{
    public class ConnectionString_Tests
    {
        [Fact]
        public void SqlConnectionStringBuilder_Test()
        {
            var csb = new SqlConnectionStringBuilder("Server=localhost; Database=Corporativohotsite; Trusted_Connection=True;");
            csb["Database"].ShouldBe("Corporativohotsite");
        }
    }
}
