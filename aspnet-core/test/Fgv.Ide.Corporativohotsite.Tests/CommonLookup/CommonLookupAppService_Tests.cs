using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Common;
using Shouldly;

namespace Fgv.Ide.Corporativohotsite.Tests.CommonLookup
{
    public class CommonLookupAppService_Tests : AppTestBase
    {
        private readonly ICommonLookupAppService _commonLookupAppService;

        public CommonLookupAppService_Tests()
        {
            LoginAsHostAdmin();
            _commonLookupAppService = Resolve<ICommonLookupAppService>();
        }

        [MultiTenantFact]
        public async Task Should_Get_Editions()
        {
            var paidEditions = await _commonLookupAppService.GetEditionsForCombobox();
            paidEditions.Items.Count.ShouldBe(7);

            var freeEditions = await _commonLookupAppService.GetEditionsForCombobox(true);
            freeEditions.Items.Count.ShouldBe(4);
        }
    }
}
