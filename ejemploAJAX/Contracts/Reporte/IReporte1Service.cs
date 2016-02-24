using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploAJAX.Contracts.Reporte
{
    interface IReporte1Service
    {
        IList<String> GenerarReporte();
    }
}
