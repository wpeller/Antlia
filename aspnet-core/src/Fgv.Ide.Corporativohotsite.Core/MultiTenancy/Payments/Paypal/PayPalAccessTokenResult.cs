using Newtonsoft.Json;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Payments.Paypal
{
    public class PayPalAccessTokenResult
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}