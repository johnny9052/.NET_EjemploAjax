using ejemploAJAX.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemploAJAX.Controllers
{
    /*Clase que tiene funciones globales*/
    public class BaseController : Controller
    {

        #region Variables

        /*Clase HELPER que permite verificar la sesion*/
        private readonly SessionVerify sessionVerifi = new SessionVerify();

        #endregion


        #region Constructors

        public BaseController()
        {
        }

        #endregion



        #region ActionResults


        /*Valida si permite cargar la vista solicitada o si lo redirecciona al index*/
        public ActionResult ReturnViewOrRedirect()
        {
            /*utilizando la clase helper para verificar sesion, si no tiene sesion redirecciona al index*/
            if (!sessionVerifi.HasSession())
            {
                /*Objeto para acceder a variables globales*/
                GeneralData data = new GeneralData();
                /*Redirecciona a una pagina especifica*/
                /*Index - Home - URL que se respondera al usuario pero que no cargara*/
                return RedirectToAction(data.ActionWithoutSession, data.ControllerWithoutSession, new { url = sessionVerifi.GetRedirectUrl() });                
            }

            /*Si la sesion esta activa retorna la vista sin ningun problema*/
            return View();
        }

        #endregion
	}
}