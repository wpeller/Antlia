using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Fgv.Ide.Corporativohotsite.Editions.Dto;

namespace Fgv.Ide.Corporativohotsite.MultiTenancy.Dto
{
    public class GetTenantFeaturesEditOutput
    {
        public List<NameValueDto> FeatureValues { get; set; }

        public List<FlatFeatureDto> Features { get; set; }
    }
}