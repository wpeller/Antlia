using Abp.Domain.Entities;
using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovimentosManuais.ApplicationCore
{
    [Table("Produto_Cosif")]
    public class Produto_Cosif : Entity<string>  
    {
        [NotMapped]
        public override string Id
        {
            get { return COD_PRODUTO + "-" + COD_COSIF; }
            set { /* nothing */ }
        }
        [Column(Order = 0), Key]
        public string COD_PRODUTO { get; set; }
        [Column(Order = 1), Key]
        public string COD_COSIF { get; set; }
        public string COD_CLASSIFICACAO { get; set; }
        public string STA_STATUS { get; set; }
       // public ICollection<Movimento_Manual> Contatos { get; set; }

      
    }
}
