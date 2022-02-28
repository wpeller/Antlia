using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.Table
{
    [Table("Inscricao")]
    public class Inscricao : Entity<long>
    {
        public string NomeInscrito { get; set; }
        public string Cpf{get;set;}
        public string Passaporte { get; set; }
        public long IdSituacaoCandidato { get; set; }
        public long  IdOferta { get; set; }
        public long IdOpcaoOferta { get; set; }

    }
}
