using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Accounting.Dto;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
