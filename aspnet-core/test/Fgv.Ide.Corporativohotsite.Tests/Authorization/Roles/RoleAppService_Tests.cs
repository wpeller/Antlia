﻿using System.Threading.Tasks;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Roles.Dto;
using Shouldly;
using Xunit;

namespace Fgv.Ide.Corporativohotsite.Tests.Authorization.Roles
{
    public class RoleAppService_Tests : AppTestBase
    {
        private readonly IRoleAppService _roleAppService;

        public RoleAppService_Tests()
        {
            _roleAppService = Resolve<IRoleAppService>();
        }

        [MultiTenantFact]
        public async Task Should_Get_Roles_For_Host()
        {
            LoginAsHostAdmin();

            //Act
            var output = await _roleAppService.GetRoles(new GetRolesInput());

            //Assert
            output.Items.Count.ShouldBe(1);
        }

        [Fact]
        public async Task Should_Get_Roles_For_Tenant()
        {
            //Act
            var output = await _roleAppService.GetRoles(new GetRolesInput());

            //Assert
            output.Items.Count.ShouldBe(2);
        }
    }
}
