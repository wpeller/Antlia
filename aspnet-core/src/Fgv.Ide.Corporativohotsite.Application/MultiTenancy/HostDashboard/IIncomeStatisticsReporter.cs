using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.MultiTenancy.HostDashboard.Dto;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}