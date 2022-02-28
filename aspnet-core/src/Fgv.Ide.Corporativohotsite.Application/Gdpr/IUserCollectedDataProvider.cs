using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Fgv.Ide.Corporativohotsite.Dto;

namespace Fgv.Ide.Corporativohotsite.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
