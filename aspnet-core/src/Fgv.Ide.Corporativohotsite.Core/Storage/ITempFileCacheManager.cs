using Abp.Dependency;

namespace Fgv.Ide.Corporativohotsite.Storage
{
    public interface ITempFileCacheManager: ITransientDependency
    {
        void SetFile(string token, byte[] content);
        void SetDocumentFile(string token, byte[] document);
		byte[] GetFile(string token);
        

    }
}
