using Xunit;

namespace Fgv.Ide.Corporativohotsite.Tests.AcessoExterno.Boundaries
{
    public class TheoryCustomAttribute : TheoryAttribute
    {
        public override string Skip
        {
            get
            {
                return TestConfig.SkipTest;
            }
            set
            {
            }
        }

        public TheoryCustomAttribute()
        {
        }
    }
}
