using System;

namespace Fgv.Ide.Corporativohotsite.HotSite
{
    public class Movimento_ManualResultDto
    {
        public Decimal DAT_ANO { get; set; }
        public Decimal DAT_MES { get; set; }
        public string COD_PRODUTO { get; set; }
        public string COD_COSIF { get; set; }
        public string DES_DESCRICAO { get; set; }
        public string COD_USUARIO { get; set; }
        public Decimal VAL_VALOR { get; set; }
        public string ProdutoDesc { get; set; }
        public string ProdutoCod { get; set; }
        public string NumeroLancamento { get; set; }
    }
}