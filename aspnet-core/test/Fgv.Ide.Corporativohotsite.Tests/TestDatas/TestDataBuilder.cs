using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;

namespace Fgv.Ide.Corporativohotsite.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly CorporativohotsiteDbContext _context;
        private readonly CorporativohotsiteApiDbContext _context2;
        private readonly int _tenantId;

        public TestDataBuilder(CorporativohotsiteDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public TestDataBuilder(CorporativohotsiteApiDbContext context, int tenantId)
        {
            _context2 = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            new TestOrganizationUnitsBuilder(_context, _tenantId).Create();
            new TestSubscriptionPaymentBuilder(_context, _tenantId).Create();
            new TestEditionsBuilder(_context).Create();

            _context.SaveChanges();
        }
    }
}
