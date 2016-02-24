using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploAJAX.Helpers
{

    /*Clase HELPER que permite verificar la sesion*/
    public class SessionVerify
    {
     
        /*Retorna true o false si se tiene sesion activa*/
        public bool HasSession()
        {
            if (HttpContext.Current.Session.Count == 0)
            {
                return false;
            }
            return true;
        }



        /*Obtiene la URL que se este solicitando*/
        public String GetRedirectUrl()
        {
            String url = HttpContext.Current.Request.Url.AbsoluteUri;
            return url;
        }

    }
}