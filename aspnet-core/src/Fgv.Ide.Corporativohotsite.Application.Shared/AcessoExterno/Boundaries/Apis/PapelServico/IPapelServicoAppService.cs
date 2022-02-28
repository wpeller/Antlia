using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.PapelServico.Dto;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.PapelServico
{
	public interface IPapelServicoAppService : IApplicationService
	{
		Task<List<PapelDto>> ObterPapeisDoUsuarioParaMenu(ObterPapeisDoUsuarioParaMenuInput input);
	}
}
