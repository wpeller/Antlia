using Newtonsoft.Json;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Payments.Paypal
{
    public class Payer
    {
        [JsonProperty("payment_method")]
        public string PaymentMethod { get; set; }
    }
}