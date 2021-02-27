using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware.Classes
{
    public class DadosGeral : IDadosGeral
    {
        public string nomeCompleto { get; set; }
        string IDadosGeral.nomeCompleto { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string email { get; set; }
        string IDadosGeral.email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string dataNascimento { get; set; }
        string IDadosGeral.dataNascimento { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string cpf { get; set; }
        string IDadosGeral.cpf { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string rg { get; set; }
        string IDadosGeral.rg { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string identificador { get; set; }
    }
}
