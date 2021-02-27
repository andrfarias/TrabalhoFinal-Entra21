using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware
{
    public interface IDadosAdvg 
    {
        string numeroAOB { get; set; }
        string cep { get; set; }
        string cidade { get; set; }
        string estado { get; set; }
        string bairro { get; set; }
        string logradouro { get; set; }
        string foto { get; set; }
        string numeroCartao1 { get; set; }
        string numeroCartao2 { get; set; }
        string numeroCartao3 { get; set; }
        string numeroCartao4 { get; set; }
        string codigoSeguranca { get; set; }
        string cepComercial { get; set; }
        string logradouroComercial { get; set; }
        string numeroEndComercial { get; set; }
        string complementoEndComercial { get; set; }
        string empresaNumeroAOB { get; set; }
        string cnpj { get; set; }
        string senha { get; set; }
        string validadeCartao { get; set; }
    }
}
