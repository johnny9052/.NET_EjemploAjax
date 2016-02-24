using ejemploAJAX.Contracts.Security;
using ejemploAJAX.DTO.Security;
using ejemploAJAX.Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemploAJAX.Controllers.Security
{
    public class SecurityController : Controller
    {


        #region Variables

        /*Objeto que tiene definidos todas las funciones, y es igualada a la interfaz del contract*/
        /*Readonly establece que el objeto solo puede ser modificado en un constructor
         * o en su definicion, si se quisiera
         modificar dicho objeto fuera de esto no lo permitira*/
        private static readonly ILoginService ContractService = new LoginService();

        #endregion

        #region ActionResults

        #endregion

        #region Login Methods

        /*El metodo solo se activa a traves de una peticion post*/
        [AcceptVerbs("POST")]
        public ActionResult UserIdentify(String usu, String pass)
        {
            /*Se define el DTO (Clase que solo define datos, no funciones que lo diferencia del modelo)*/
            LoginDTO objDTO = new LoginDTO(usu, pass);
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.LoginUser(objDTO);
            /*Lista temporal que contendra la respuesta que se le dara al cliente*/
            IList<String> res = new List<String>();
            /*Se valida si la consulta SQL retorno valores*/
            if (info != null && info.Count() > 1)
            {
                /*Se crea variables de sesion*/
                CreateUserSession(info);
                res.Add("Status");
                res.Add("Success");
            }

            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = res });
        }


        /*Se crean variables de sesion a partir de lo retornado por la consulta SQL*/
        private void CreateUserSession(IEnumerable<String> info)
        {
            if (Session.Count == 0 && info.ToArray().Count() > 1)
            {
                Session["USER_ID"] = info.ElementAt(0);
                Session["USER_NAME"] = info.ElementAt(1);
            }
        }

        #endregion




        #region Logout Methods


        /*El metodo solo se activa a traves de una peticion post*/
        [AcceptVerbs("POST")]
        public ActionResult LogOut()
        {
            try
            {                
                /*Cancela la sesion actual*/
                Session.Abandon();
                /*Destruye variables de sesion*/
                Session.RemoveAll();
                return Json(new { resp = "Success" });
            }
            catch (Exception)
            {
                return Json(new { resp = "NotInfo" });
            }
        }

        #endregion

    }
}