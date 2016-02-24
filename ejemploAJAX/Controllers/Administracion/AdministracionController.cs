using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemploAJAX.Controllers.Administracion
{

    /*Se hereda del controlador base para tener acceso a las validaciones de sesion*/
    public class AdministracionController : BaseController
    {

        /*Se definen los action result, para responder las solicitudes de carga de pagina*/
        public ActionResult Municipios()
        {
            /*Valida si se puede redireccinar la pagina solicitada o si retorna al index*/
            return ReturnViewOrRedirect();
        }


        public ActionResult Usuarios()
        {
            /*Valida si se puede redireccinar la pagina solicitada o si retorna al index*/
            return ReturnViewOrRedirect();
        }
    }
}