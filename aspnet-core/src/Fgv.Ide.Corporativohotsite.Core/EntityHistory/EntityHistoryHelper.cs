﻿using System;
using System.Linq;
using Abp.Organizations;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.MultiTenancy;

namespace Fgv.Ide.Corporativohotsite.EntityHistory
{
    public static class EntityHistoryHelper
    {
        public static readonly Type[] HostSideTrackedTypes =
        {
            typeof(OrganizationUnit), typeof(Role), typeof(Tenant)
        };

        public static readonly Type[] TenantSideTrackedTypes =
        {
            typeof(OrganizationUnit), typeof(Role)
        };

        public static readonly Type[] TrackedTypes =
            HostSideTrackedTypes
                .Concat(TenantSideTrackedTypes)
                .GroupBy(type=>type.FullName)
                .Select(types=>types.First())
                .ToArray();
    }
}
