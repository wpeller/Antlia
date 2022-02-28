﻿using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.MultiTenancy.HostDashboard.Dto;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.HostDashboard
{
    public interface IHostDashboardAppService : IApplicationService
    {
        Task<HostDashboardData> GetDashboardStatisticsData(GetDashboardDataInput input);

        Task<GetIncomeStatisticsDataOutput> GetIncomeStatistics(GetIncomeStatisticsDataInput input);

        Task<GetEditionTenantStatisticsOutput> GetEditionTenantStatistics(GetEditionTenantStatisticsInput input);
    }
}