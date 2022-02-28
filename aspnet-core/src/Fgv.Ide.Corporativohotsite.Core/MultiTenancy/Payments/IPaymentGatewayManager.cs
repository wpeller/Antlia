using System.Collections.Generic;
using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Editions;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Payments
{
    public interface IPaymentGatewayManager
    {
        Task<CreatePaymentResponse> CreatePaymentAsync(string description, decimal amount);

        Task<ExecutePaymentResponse> ExecutePaymentAsync(Dictionary<string, string> data);

        Task<Dictionary<string, string>> GetAdditionalPaymentData(SubscribableEdition edition);
    }
}
