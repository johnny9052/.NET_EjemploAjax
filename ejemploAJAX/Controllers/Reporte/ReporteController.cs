using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemploAJAX.Controllers.Reporte
{
    public class ReporteController : BaseController
    {
        /*Se definen los action result, para responder las solicitudes de carga de pagina*/
        public ActionResult Reporte1()
        {
            /*Valida si se puede redireccinar la pagina solicitada o si retorna al index*/
            return ReturnViewOrRedirect();
        }

    }
}