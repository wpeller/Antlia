using System;
using System.Threading.Tasks;

namespace Fgv.Ide.Corporativohotsite.Storage
{
    public interface IBinaryObjectManager
    {
        Task<BinaryObject> GetOrNullAsync(Guid id);
        
        Task SaveAsync(BinaryObject file);
        
        Task DeleteAsync(Guid id);
    }
}