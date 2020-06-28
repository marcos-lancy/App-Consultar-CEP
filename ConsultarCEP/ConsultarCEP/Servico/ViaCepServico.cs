using ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ConsultarCEP.Servico
{
    public class ViaCepServico
    {
        private static string _enderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoUrl = string.Format(_enderecoUrl, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoUrl);

            return JsonConvert.DeserializeObject<Endereco>(conteudo);
        }

    }
}
