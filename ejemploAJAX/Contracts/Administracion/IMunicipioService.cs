using ejemploAJAX.DTO.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploAJAX.Contracts.Administracion
{
    interface IMunicipioService
    {

        IList<String> SaveInfo(MunicipioDTO objDTO);
        IList<String> ListInfo();
        IList<String> SearchInfo(String usuario);
        IList<String> DeleteInfo(int id);
        IList<String> LoadDepartamento();
    }
}