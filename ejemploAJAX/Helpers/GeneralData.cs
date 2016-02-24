using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploAJAX.Helpers
{
    /*Definicion de variables globales del sistema*/
    public class GeneralData
    {

        /*Readonly establece que el objeto solo puede ser modificado en un constructor o en su definicion, si se quisiera
         modificar dicho objeto fuera de esto no lo permitira*/

        /*establece el nombre por defecto archivo de la vista que se ejecuta si no se tiene sesion activa*/
        private readonly String _action = "Index";
        /*establece el nombre por defecto archivo del controlador que se ejecuta si no se tiene sesion activa*/
        private readonly String _controller = "Home";


        /*Devuelve la fecha actual del sistema*/
        public String CurrentDateString { get { return DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss"); } }

        /*Accesor*/
        public String ActionWithoutSession { get { return _action; } }

        /*Accesor*/
        public String ControllerWithoutSession { get { return _controller; } }

    }
}