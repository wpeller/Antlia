using System;

namespace Fgv.Ide.Corporativohotsite.HotSite.Dto
{
    public class OutputInscrever
    {
        public string RedirectTo { get; set; }
        public long? IdOferta { get; set; }
        public long IdOpcaoOferta { get; set; }
        public string NomeCandidato { get; set; }
        public string DDDTelefone { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
    }
}
