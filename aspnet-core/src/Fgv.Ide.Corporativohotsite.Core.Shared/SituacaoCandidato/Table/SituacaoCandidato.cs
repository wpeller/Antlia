using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.Table
{
    [Table("SituacaoCandidato")]
    public class SituacaoCandidato : Entity<long>
    {
        public string Descricao { get; set; }
        public string Mnemonico { get; set; }       
    }
}
