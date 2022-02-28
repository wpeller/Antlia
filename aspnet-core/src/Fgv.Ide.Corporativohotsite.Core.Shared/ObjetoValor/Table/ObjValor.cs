using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fgv.Ide.Corporativohotsite.ObjetoValor.Table
{
    [Table("ObjetoValor")]
    public class ObjValor : Entity<long>
    {
        public string Discriminator { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
