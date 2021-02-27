using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware.Classes
{
    public class DadosAdvg : DadosGeral, IDadosAdvg
    {
        public string nomeCompleto { get; set; }
        public string cpf { get; set; }
        public string rg { get; set; }
        public string numeroAOB { get; set; }
        public string cep { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string bairro { get; set; }
        public string logradouro { get; set; }
        public string foto { get; set; }
        public string numeroCartao1 { get; set; }
        public string numeroCartao2 { get; set; }
        public string numeroCartao3 { get; set; }
        public string numeroCartao4 { get; set; }
        public string codigoSeguranca { get; set; }
        public string cepComercial { get; set; }
        public string logradouroComercial { get; set; }
        public string numeroEndComercial { get; set; }
        public string complementoEndComercial { get; set; }
        public string empresaNumeroAOB { get; set; }
        public string cnpj { get; set; }
        public string senha { get; set; }
        public string email { get; set; }
        public string dataNascimento { get; set; }
        public string validadeCartao { get; set; }
    }
}
