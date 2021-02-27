using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware.Classes
{
    class DadosCliente : DadosGeral, IDadosCliente
    {
        public string NrProcesso { get; set; }
        public string dtInicio { get; set; }
        public string dtFinal { get; set; }
        public string dtInicioSemi { get; set; }
        public string dtInicioAberto { get; set; }
        public string diasPena { get; set; }

    }
}
