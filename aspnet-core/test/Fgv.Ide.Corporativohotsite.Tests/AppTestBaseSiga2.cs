using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Abp.TestBase;
using Fgv.Ide.Corporativohotsite.EntityFrameworkCore;
using Fgv.Ide.Corporativohotsite.Tests.TestDatas;
using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.EntityFrameworkCore.Extensions;
using Abp.Runtime.Session;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Castle.MicroKernel.Registration;
using Fgv.Ide.Corporativohotsite.Configuration;

namespace Fgv.Ide.Corporativohotsite.Tests
{
    public abstract class AppTestBaseSiga2 : AbpIntegratedTestBase<CorporativohotsiteTestModule>
    {
        private static bool _IocManagerRegister;

        protected AppTestBaseSiga2()
        {
            IocManagerRegister();
            //SeedTestData();
            //LoginAsDefaultTenantAdmin();
        }

        private void IocManagerRegister()
        {
            if (_IocManagerRegister) return;

            _IocManagerRegister = true;
            IocManager.Instance.IocContainer.Register(Component.For<IAppConfigurationAccessor>().UsingFactoryMethod(kernel => { return Resolve<IAppConfigurationAccessor>(); }));
        }
        private void SeedTestData()
        {
            void NormalizeDbContext(CorporativohotsiteApiDbContext context)
            {
                context.EntityChangeEventHelper = NullEntityChangeEventHelper.Instance;
                context.EventBus = NullEventBus.Instance;
                context.SuppressAutoSetTenantId = true;
            }

            //Seed initial data for default tenant
            AbpSession.TenantId = 1;
            UsingDbContext(context =>
            {
                NormalizeDbContext(context);
                new TestDataBuilder(context, 1).Create();
            });
        }
        protected IDisposable UsingTenantId(int? tenantId)
        {
            var previousTenantId = AbpSession.TenantId;
            AbpSession.TenantId = tenantId;
            return new DisposeAction(() => AbpSession.TenantId = previousTenantId);
        }

        protected void UsingDbContext(Action<CorporativohotsiteApiDbContext> action)
        {
            UsingDbContext(AbpSession.TenantId, action);
        }

        protected Task UsingDbContextAsync(Func<CorporativohotsiteApiDbContext, Task> action)
        {
            return UsingDbContextAsync(AbpSession.TenantId, action);
        }

        protected T UsingDbContext<T>(Func<CorporativohotsiteApiDbContext, T> func)
        {
            return UsingDbContext(AbpSession.TenantId, func);
        }

        protected Task<T> UsingDbContextAsync<T>(Func<CorporativohotsiteApiDbContext, Task<T>> func)
        {
            return UsingDbContextAsync(AbpSession.TenantId, func);
        }

        protected void UsingDbContext(int? tenantId, Action<CorporativohotsiteApiDbContext> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<CorporativohotsiteApiDbContext>())
                {
                    action(context);
                    context.SaveChanges();
                }
            }
        }

        protected async Task UsingDbContextAsync(int? tenantId, Func<CorporativohotsiteApiDbContext, Task> action)
        {
            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<CorporativohotsiteApiDbContext>())
                {
                    await action(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected T UsingDbContext<T>(int? tenantId, Func<CorporativohotsiteApiDbContext, T> func)
        {
            T result;

            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<CorporativohotsiteApiDbContext>())
                {
                    result = func(context);
                    context.SaveChanges();
                }
            }

            return result;
        }

        protected async Task<T> UsingDbContextAsync<T>(int? tenantId, Func<CorporativohotsiteApiDbContext, Task<T>> func)
        {
            T result;

            using (UsingTenantId(tenantId))
            {
                using (var context = LocalIocManager.Resolve<CorporativohotsiteApiDbContext>())
                {
                    result = await func(context);
                    await context.SaveChangesAsync();
                }
            }

            return result;
        }



    }
}
