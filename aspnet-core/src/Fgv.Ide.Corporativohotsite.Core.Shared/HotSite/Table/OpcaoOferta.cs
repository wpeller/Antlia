using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.Table
{
    [Table("OpcaoOferta")]
    public class OpcaoOferta : Entity<long>
    {
        [Column("IdOpcaoOferta")]
        public override long Id { get => base.Id; set => base.Id = value; }
        public long? IdOferta { get; set; }
        public string Turma { get; set; }
    }
}
