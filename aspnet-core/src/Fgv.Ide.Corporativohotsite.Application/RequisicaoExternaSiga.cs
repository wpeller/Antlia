using Abp.Dependency;
using Fgv.Ide.Corporativohotsite.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Fgv.Ide.Corporativohotsite
{
    public enum HttpVerbEnum
    {
        desconhecido = 0,
        get = 1,
        post = 2,
        put = 3,
        delete = 4,
    }

    public class RequisicaoExternaSiga : IRequisicaoExternaSiga
    {
        private string _url;
        private string _method;
        private Dictionary<string, string> _header;
        private readonly IAppConfigurationAccessor _configuration;

        public RequisicaoExternaSiga(IAppConfigurationAccessor configuration)
        {
            _configuration = configuration;
        }

        public RequisicaoExternaSiga(string url, string method, IAppConfigurationAccessor configuration, Dictionary<string, string> header = null)
        {
            _url = url;
            _method = method;
            _configuration = configuration;
            _header = header;
        }

        public RequisicaoExternaSiga(string url, string method)
        {
            _url = url;
            _method = method;
            _configuration = IocManager.Instance.Resolve<IAppConfigurationAccessor>();
        }

        private HttpResponseMessage RequisitarContent_Get(HttpClient client)
        {
            return client
                .GetAsync($"{_url}/{_method}")
                .GetAwaiter()
                .GetResult();
        }

        private HttpResponseMessage RequisitarContent_Post(HttpClient client, StringContent parametro)
        {
            return client
                .PostAsync($"{_url}/{_method}", parametro)
                .GetAwaiter()
                .GetResult();
        }

        private HttpResponseMessage RequisitarContent_Put(HttpClient client, StringContent parametro)
        {
            return client
                .PutAsync($"{_url}/{_method}", parametro)
                .GetAwaiter()
                .GetResult();
        }

        private HttpResponseMessage RequisitarContent_Delete(HttpClient client)
        {
            return client
                .DeleteAsync($"{_url}/{_method}")
                .GetAwaiter()
                .GetResult();
        }

        private HttpContent RequisitarContent(StringContent parametro, HttpVerbEnum httpVerb)
        {
            var client = new HttpClient();

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            ServicePointManager.ServerCertificateValidationCallback += (send, certificate, chain, sslPolicyErrors) => { return true; };

            client.DefaultRequestHeaders.Accept.Clear();
            //client.MaxResponseContentBufferSize = 655360000;
            // blindagem: todo consumo aos servicos do Siga2 deve enviar o header ApiKey
            client.DefaultRequestHeaders.Add("ApiKey", _configuration.Configuration["App.Siga2WebServices.ApiKey"]);

            if (_header != null && _header.Any())
                _header.ToList().ForEach(x => client.DefaultRequestHeaders.Add(x.Key, x.Value));

            HttpResponseMessage response = null;

            switch (httpVerb)
            {
                case HttpVerbEnum.desconhecido:
                    response = RequisitarContent_Post(client, parametro);
                    break;
                case HttpVerbEnum.get:
                    response = RequisitarContent_Get(client);
                    break;
                case HttpVerbEnum.post:
                    response = RequisitarContent_Post(client, parametro);
                    break;
                case HttpVerbEnum.put:
                    response = RequisitarContent_Put(client, parametro);
                    break;
                case HttpVerbEnum.delete:
                    response = RequisitarContent_Delete(client);
                    break;
                default:
                    response = RequisitarContent_Post(client, parametro);
                    break;
            }

            return response.Content;
        }

        private string RequisitarContentResult(StringContent parametro, HttpVerbEnum httpVerb)
        {
            var content = RequisitarContent(parametro, httpVerb);

            return content.ReadAsStringAsync().Result;
        }

        private JToken RequisitarContentResultJToken(StringContent parametro, HttpVerbEnum httpVerb)
        {
            var result = RequisitarContentResult(parametro, httpVerb);

            var objJson = JObject.Parse(result);

            if (objJson.ContainsKey("success"))
            {
                if (objJson["success"].Value<bool>())
                {
                    if (objJson.ContainsKey("d"))
                        return objJson["d"];
                }
                else if (objJson.ContainsKey("error"))
                    throw new Exception(objJson["error"].ToString());
            }
            else if (objJson.ContainsKey("d"))
                return objJson["d"];

            return objJson;
        }

        public T Requisitar<T>(StringContent parametro = null, HttpVerbEnum httpVerb = HttpVerbEnum.post) where T : class, new()
        {
            var objJson = RequisitarContentResultJToken(parametro, httpVerb);

            return objJson.ToObject<T>();
        }

        public String RequisitarComRetornoString(StringContent parametro = null, HttpVerbEnum httpVerb = HttpVerbEnum.post)
        {
            var objJson = RequisitarContentResultJToken(parametro, httpVerb);

            return objJson.ToString();
        }

        public byte[] RequisitarComRetornoBytes(StringContent parametro = null, HttpVerbEnum httpVerb = HttpVerbEnum.post)
        {
            var content = RequisitarContent(parametro, httpVerb);

            return content.ReadAsByteArrayAsync().Result;
        }

        public T Requisitar<T>(string url, string method, StringContent parametro) where T : class, new()
        {
            _url = url;
            _method = method;

            return Requisitar<T>(parametro);
        }

        public String RequisitarComRetornoString(string url, string method, StringContent parametro)
        {
            _url = url;
            _method = method;

            return RequisitarComRetornoString(parametro);
        }

        public byte[] RequisitarComRetornoBytes(string url, string method, StringContent parametro)
        {
            _url = url;
            _method = method;

            return RequisitarComRetornoBytes(parametro);
        }
    }
}
