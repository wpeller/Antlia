using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.UsuarioServico.Dto
{
    public class ValidaUsuarioTemPermissaoDto
    {
        public string Rota { get; set; }
        public long? PapelId { get; set; }
        public string UsuarioCodigoExterno { get; set; }
    }
}
