using System;
using System.Net.Http;

namespace Fgv.Ide.Corporativohotsite
{
    public interface IRequisicaoExternaSiga
    {
        T Requisitar<T>(string url, string method, StringContent parametro) where T : class, new();
        String RequisitarComRetornoString(string url, string method, StringContent parametro);
        byte[] RequisitarComRetornoBytes(string url, string method, StringContent parametro);
    }
}
