using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware
{
    public interface IDadosGeral
    {
        string nomeCompleto { get; set; }
        string email { get; set; }
        string dataNascimento { get; set; }
        string cpf { get; set; }
        string rg { get; set; }
    }
}
