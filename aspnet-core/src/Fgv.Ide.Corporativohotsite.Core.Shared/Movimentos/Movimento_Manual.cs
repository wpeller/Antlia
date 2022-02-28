using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovimentosManuais.ApplicationCore.Entity
{
    [Table("Movimento_Manual")]
    public class Movimento_Manual : Entity<string>
    {

        [NotMapped]
        public override string Id
        {
            get { return $"{COD_COSIF}-{NUM_LANCAMENTO}" ; }
            set { /* nothing */ }
        }
        public Decimal DAT_ANO { get; set; }
        public Decimal DAT_MES { get; set; }


        [Column(Order = 0), Key]
        public Decimal NUM_LANCAMENTO { get; set; }


        [Column(Order = 1), Key]
        [ForeignKey("COD_PRODUTO")]
        public Produto Produto { get; set; }


        //[Column(Order = 1), Key]
        //public string COD_PRODUTO { get; set; }
        [Column(Order = 2), Key]
        public string COD_COSIF { get; set; }


        public string DES_DESCRICAO { get; set; }
        public DateTime DAT_MOVIMENTO { get; set; }
        public string COD_USUARIO { get; set; }
        public Decimal VAL_VALOR { get; set; }
    }
}
