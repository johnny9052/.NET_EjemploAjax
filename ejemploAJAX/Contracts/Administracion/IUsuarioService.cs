using ejemploAJAX.DTO.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploAJAX.Contracts.Administracion
{
    interface IUsuarioService
    {

        IList<String> SaveInfo(UsuarioDTO objDTO);
        IList<String> ListInfo();
        IList<String> SearchInfo(String usuario);
        IList<String> DeleteInfo(int id);

    }
}