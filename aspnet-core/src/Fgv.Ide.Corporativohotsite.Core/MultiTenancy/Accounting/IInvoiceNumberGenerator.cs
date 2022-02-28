﻿using System.Threading.Tasks;
using Abp.Dependency;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}