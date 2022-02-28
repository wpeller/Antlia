using Abp.Domain.Entities;
using MovimentosManuais.ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MovimentosManuais.ApplicationCore
{
    [Table("Produto")]

    public class Produto : Entity<string>
    {
        //[Key]
        //public string COD_PRODUTO { get; set; }
        public string DES_PRODUTO { get; set; }
        public string STA_STATUS { get; set; }
        // public ICollection<Produto_Cosif> Produto_Cosifs { get; set; }
        public ICollection<Movimento_Manual> Movimentos { get; set; }
    }
}
