using Fgv.Ide.Corporativohotsite.Editions.Dto;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Payments.Dto
{
    public class PaymentInfoDto
    {
        public EditionSelectDto Edition { get; set; }

        public decimal AdditionalPrice { get; set; }
    }
}
