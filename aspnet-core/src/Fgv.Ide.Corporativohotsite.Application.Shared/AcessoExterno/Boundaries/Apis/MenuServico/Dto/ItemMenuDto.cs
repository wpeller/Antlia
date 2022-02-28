using System.Collections.Generic;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.MenuServico.Dto
{
	public class ItemMenuDto
	{
        public long Id { get; set; }
        public string Titulo { get; set; }
        public List<ItemMenuDto> Filhos { get; set; }
        public string BreadCrumb { get; set; }
        public string Url { get; set; }
        public string Rota { get; set; }
        public string ModuloAcesso { get; set; }
    }
}
