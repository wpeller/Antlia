using Fgv.Ide.Corporativohotsite.Applications.Dtos;
using Fgv.Ide.Corporativohotsite.Applications;
using Abp.Application.Editions;
using Abp.Application.Features;
using Abp.Auditing;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.EntityHistory;
using Abp.Localization;
using Abp.Notifications;
using Abp.Organizations;
using Abp.UI.Inputs;
using AutoMapper;
using Fgv.Ide.Corporativohotsite.Auditing.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Accounts.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Permissions.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Roles;
using Fgv.Ide.Corporativohotsite.Authorization.Roles.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Users;
using Fgv.Ide.Corporativohotsite.Authorization.Users.Dto;
using Fgv.Ide.Corporativohotsite.Authorization.Users.Profile.Dto;
using Fgv.Ide.Corporativohotsite.Editions;
using Fgv.Ide.Corporativohotsite.Editions.Dto;
using Fgv.Ide.Corporativohotsite.Localization.Dto;
using Fgv.Ide.Corporativohotsite.MultiTenancy;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Dto;
using Fgv.Ide.Corporativohotsite.MultiTenancy.HostDashboard.Dto;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Payments;
using Fgv.Ide.Corporativohotsite.MultiTenancy.Payments.Dto;
using Fgv.Ide.Corporativohotsite.Navigations;
using Fgv.Ide.Corporativohotsite.Notifications.Dto;
using Fgv.Ide.Corporativohotsite.Organizations.Dto;
using Fgv.Ide.Corporativohotsite.Sessions.Dto;
using Fgv.Ide.Corporativohotsite.HotSite.Dto;
using Fgv.Ide.Corporativohotsite.HotSite.View;
using Fgv.Ide.Corporativohotsite.HotSite;
using MovimentosManuais.ApplicationCore.Entity;

namespace Fgv.Ide.Corporativohotsite
{
    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
           configuration.CreateMap<CreateOrEditApplicationDto, Application>();
           configuration.CreateMap<Application, ApplicationDto>();
            //Inputs
            configuration.CreateMap<CheckboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<SingleLineStringInputType, FeatureInputTypeDto>();
            configuration.CreateMap<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<IInputType, FeatureInputTypeDto>()
                .Include<CheckboxInputType, FeatureInputTypeDto>()
                .Include<SingleLineStringInputType, FeatureInputTypeDto>()
                .Include<ComboboxInputType, FeatureInputTypeDto>();
            configuration.CreateMap<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<ILocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>()
                .Include<StaticLocalizableComboboxItemSource, LocalizableComboboxItemSourceDto>();
            configuration.CreateMap<LocalizableComboboxItem, LocalizableComboboxItemDto>();
            configuration.CreateMap<ILocalizableComboboxItem, LocalizableComboboxItemDto>()
                .Include<LocalizableComboboxItem, LocalizableComboboxItemDto>();

            //Feature
            configuration.CreateMap<FlatFeatureSelectDto, Feature>().ReverseMap();
            configuration.CreateMap<Feature, FlatFeatureDto>();

            //Role
            configuration.CreateMap<RoleEditDto, Role>().ReverseMap();
            configuration.CreateMap<Role, RoleListDto>();
            configuration.CreateMap<UserRole, UserListRoleDto>();

            //Edition
            configuration.CreateMap<EditionEditDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<EditionSelectDto, SubscribableEdition>().ReverseMap();
            configuration.CreateMap<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionInfoDto>().Include<SubscribableEdition, EditionInfoDto>();

            configuration.CreateMap<Edition, EditionListDto>();
            configuration.CreateMap<Edition, EditionEditDto>();
            configuration.CreateMap<Edition, SubscribableEdition>();
            configuration.CreateMap<Edition, EditionSelectDto>();


            //Payment
            configuration.CreateMap<SubscriptionPaymentDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPaymentListDto, SubscriptionPayment>().ReverseMap();
            configuration.CreateMap<SubscriptionPayment, SubscriptionPaymentInfoDto>();

            //Permission
            configuration.CreateMap<Permission, FlatPermissionDto>();
            configuration.CreateMap<Permission, FlatPermissionWithLevelDto>();

            //Language
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageListDto>();
            configuration.CreateMap<NotificationDefinition, NotificationSubscriptionWithDisplayNameDto>();
            configuration.CreateMap<ApplicationLanguage, ApplicationLanguageEditDto>()
                .ForMember(ldto => ldto.IsEnabled, options => options.MapFrom(l => !l.IsDisabled));

            //Tenant
            configuration.CreateMap<Tenant, RecentTenant>();
            configuration.CreateMap<Tenant, TenantLoginInfoDto>();
            configuration.CreateMap<Tenant, TenantListDto>();
            configuration.CreateMap<TenantEditDto, Tenant>().ReverseMap();
            configuration.CreateMap<CurrentTenantInfoDto, Tenant>().ReverseMap();

            //User
            configuration.CreateMap<User, UserEditDto>()
                .ForMember(dto => dto.Password, options => options.Ignore())
                .ReverseMap()
                .ForMember(user => user.Password, options => options.Ignore());
            configuration.CreateMap<User, UserLoginInfoDto>();
            configuration.CreateMap<User, UserListDto>();
            configuration.CreateMap<User, OrganizationUnitUserListDto>();
            configuration.CreateMap<CurrentUserProfileEditDto, User>().ReverseMap();
            configuration.CreateMap<UserLoginAttemptDto, UserLoginAttempt>().ReverseMap();

            //AuditLog
            configuration.CreateMap<AuditLog, AuditLogListDto>();
            configuration.CreateMap<EntityChange, EntityChangeListDto>();

            //OrganizationUnit
            configuration.CreateMap<OrganizationUnit, OrganizationUnitDto>();

            /* ADD YOUR OWN CUSTOM AUTOMAPPER MAPPINGS HERE */

            configuration.CreateMap<NavigationDto, Navigation>()
                .ForMember(dst => dst.RequiredPermissionName, options => options.MapFrom(x => x.PermissionName))
                .ForMember(dst => dst.ChildrenNavigations, options => options.MapFrom(x => x.Items))
                .ForMember(dst => dst.UrlPath, options => options.MapFrom(x => x.Route))
                .ForMember(dst => dst.LocalizableDisplayName, options => options.MapFrom(x => x.Name))
                .ForMember(dst => dst.Name, options => options.MapFrom(x => x.Name))
                .ForMember(dst => dst.Module, options =>
                {
                    options.Condition((src, dst) => string.IsNullOrEmpty(dst.Module));
                    options.MapFrom(x => CorporativohotsiteConsts.ModuleName);
                });

            configuration.CreateMap<InfoGerenciarInscritosHotSiteIncompany, HotSiteInscritosDto>().ReverseMap();

            configuration.CreateMap<HotSiteTurmaDto, HotSite.Table.HotSiteInCompanyTurmaComHabilitacao>().ReverseMap()
                .ForMember(dst => dst.CodigoTurma , options => options.MapFrom(x => x.CodigoTurma ))
                .ForMember(dst => dst.DataFim  , options => options.MapFrom(x => x.DataFim  ))
                .ForMember(dto => dto.GetTurmaCurso , options => options.Ignore())                                
                .ForMember(dst => dst.DataInicio , options => options.MapFrom(x => x.DataInicio));

            configuration.CreateMap<HotSiteTurmaDto, HotSite.Table.HotSiteInCompanyTurma>()
                .ForMember(dst => dst.CodigoTurma, options => options.MapFrom(x => x.CodigoTurma))
                .ForMember(dst => dst.DataFim, options => options.MapFrom(x => x.DataFim))
                .ForMember(dto => dto.GetTurmaCurso, options => options.Ignore())
                .ForMember(dto => dto.Id, options => options.Ignore())
                .ForMember(dto => dto.IdHotSiteIncompany, options => options.Ignore())
                .ForMember(dto => dto.NomeCurso, options => options.Ignore())
                .ForMember(dst => dst.DataInicio, options => options.MapFrom(x => x.DataInicio));

            configuration.CreateMap<Movimento_ManualDto, Movimento_Manual>()
                 .ForMember(dto => dto.Id, options => options.Ignore())
                 .ForMember(dto => dto.DAT_MOVIMENTO, options => options.Ignore())
                  .ForMember(dto => dto.NUM_LANCAMENTO , options => options.Ignore())                 
                  .ReverseMap()
                  .ForMember(dto => dto.ProdutoDesc , options => options.Ignore())
                   .ForPath(dto => dto.ProdutoDesc, opt => opt.MapFrom(src => src.Produto.DES_PRODUTO ))
                  .ForMember(dto => dto.ProdutoCod , options => options.Ignore())
                  .ForPath(dto => dto.ProdutoCod, opt => opt.MapFrom(src => src.Produto.Id));


            configuration.CreateMap<Movimento_ManualResultDto, Movimento_Manual>()
              .ForMember(dto => dto.Id, options => options.Ignore())
              .ForMember(dto => dto.DAT_MOVIMENTO, options => options.Ignore())
              .ForMember(dst => dst.NUM_LANCAMENTO, options => options.MapFrom(x => x.NumeroLancamento))
               .ReverseMap()
               .ForMember(dto => dto.ProdutoDesc, options => options.Ignore())
                .ForPath(dto => dto.ProdutoDesc, opt => opt.MapFrom(src => src.Produto.DES_PRODUTO))
               .ForMember(dto => dto.ProdutoCod, options => options.Ignore())
               .ForPath(dto => dto.ProdutoCod, opt => opt.MapFrom(src => src.Produto.Id));

            //.ForMember(dto => dto.IdOferta, options => options.Ignore())
            //    .ForPath(dto => dto.IdOferta, opt => opt.MapFrom(src => src.Oferta.Id))

            //     .ForMember(dto => dto.Produto.DES_PRODUTO, options => options.MapFrom(x => x.ProdutoDesc))
            //      .ForMember(dto => dto.Produto.Id, options => options.MapFrom(x => x.ProdutoCod))
        }
    }
}