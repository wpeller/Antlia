using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;

namespace Fgv.Ide.Corporativohotsite.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class CorporativohotsiteRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<CorporativohotsiteDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CorporativohotsiteRepositoryBase(IDbContextProvider<CorporativohotsiteDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add your common methods for all repositories
    }

    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="CorporativohotsiteRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class CorporativohotsiteRepositoryBase<TEntity> : CorporativohotsiteRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CorporativohotsiteRepositoryBase(IDbContextProvider<CorporativohotsiteDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)!!!
    }
}
