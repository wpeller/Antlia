using Abp.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fgv.Ide.Corporativohotsite.HotSite.View
{
    [Table("HotSiteHabilitacaoPreviaDto")]
    public class HotSiteHabilitacaoPrevia : Entity<long>
    {
        [Column("IdInscricao")]
        public override long Id { get => base.Id; set => base.Id = value; }
        public string CPF { get; set; }
        public string Turma { get; set; }
        public string Email { get; set; }
        public string NomeInscrito { get; set; }
        public string DDDCelular { get; set; }
        public string Celular { get; set; }
        public DateTime DataNascimento { get; set; }
        public long? IdOferta { get; set; }
        public long IdOpcaoOferta { get; set; }
    }
}
