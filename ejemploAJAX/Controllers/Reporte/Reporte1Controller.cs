using ejemploAJAX.Contracts.Reporte;
using ejemploAJAX.Services.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemploAJAX.Controllers.Reporte
{
    public class Reporte1Controller : Controller
    {
        #region Variables

        /*Objeto que tiene definidos todas las funciones, y es igualada a la interfaz del contract*/
        /*Readonly establece que el objeto solo puede ser modificado en un constructor o en su definicion, si se quisiera
         modificar dicho objeto fuera de esto no lo permitira*/
        private static readonly IReporte1Service ContractService = new Reporte1Service();

        #endregion


        public ActionResult GenerarReporte()
        {
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.GenerarReporte();
            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = info });
        }
    }
}