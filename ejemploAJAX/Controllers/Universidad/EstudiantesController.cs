using ejemploAJAX.Contracts.Administracion;
using ejemploAJAX.DTO.Administracion;
using ejemploAJAX.Services.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ejemploAJAX.Controllers.Universidad
{
    public class EstudiantesController : BaseController
    {
        #region Variables

        /*Objeto que tiene definidos todas las funciones, y es igualada a la interfaz del contract*/
        /*Readonly establece que el objeto solo puede ser modificado en un constructor o en su definicion, si se quisiera
         modificar dicho objeto fuera de esto no lo permitira*/
        private static readonly IEstudianteService ContractService = new EstudianteService();

        #endregion

        #region ActionResults

        #endregion


        #region Login Methods


        public ActionResult SaveInfo(int id, String nombre, String apellido, int semestre, String documento, int municipio)
        {
            /*Se define el DTO (Clase que solo define datos, no funciones que lo diferencia del modelo)*/
            EstudianteDTO objDTO = new EstudianteDTO(id, nombre, apellido, semestre, documento, municipio);
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.SaveInfo(objDTO);
            /*Lista temporal que contendra la respuesta que se le dara al cliente*/
            IList<String> res = new List<String>();

            /*Se valida si la consulta SQL retorno valores*/
            if (info != null && info.Count() > 0)
            {
                res.Add("Status");
                res.Add("Success");
            }
            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = res });
        }



        public ActionResult SearchInfo(String documento)
        {
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.SearchInfo(documento);
            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = info });
        }


        public ActionResult ListInfo()
        {
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.ListInfo();
            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = info });
        }


        public ActionResult LoadDepartamento()
        {
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.LoadDepartamento();
            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = info });
        }



        public ActionResult LoadMunicipio(int departamento)
        {
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.LoadMunicipio(departamento);
            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = info });
        }

        public ActionResult DeleteInfo(int id)
        {
            /*Se recibe en una lista generica el resultado del login definida en el service y obligada por el contract*/
            IEnumerable<String> info = ContractService.DeleteInfo(id);
            /*Lista temporal que contendra la respuesta que se le dara al cliente*/
            IList<String> res = new List<String>();

            /*Se valida si la consulta SQL retorno valores*/
            if (info != null && info.Count() > 0)
            {
                res.Add("Status");
                res.Add("Success");
            }

            /*Se para la lista de la respuesta a JSON*/
            return Json(new { d = res });
        }

        #endregion

    }
}

