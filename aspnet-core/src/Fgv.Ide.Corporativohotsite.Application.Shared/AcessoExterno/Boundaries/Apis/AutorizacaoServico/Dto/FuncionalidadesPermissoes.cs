﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.AcessoExterno.Boundaries.Apis.AutorizacaoServico.Dto
{
    public class FuncionalidadesPermissoes
    {
        public long Recurso { get; set; }
        public List<RecursoFuncionalidade> Permissoes { get; set; }
    }
}
