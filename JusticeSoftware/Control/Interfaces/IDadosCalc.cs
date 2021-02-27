using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JusticeSoftware
{
    interface IDadosCalc
    {
        int AnosPena { get; set; }
        int MesesPena { get; set; }
        int DiasPena { get; set; }
        int DiasRemicao { get; set; }
        DateTime DtInicio{ get; set; } // usar um var para receber
        DateTime DtIncioSemiAberto{ get; set; } // usar um var para receber
        DateTime DtIncioAberto { get; set; } // usar um var para receber
        DateTime DtFinal { get; set; } // usar um var para receber

    }
}
