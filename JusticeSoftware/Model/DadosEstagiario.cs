using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware.Classes
{
    public class DadosEstagiario : DadosGeral, IDadosEstagiario
    {
        public string OABVinculada { get; set; }
    }
}
