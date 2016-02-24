using ejemploAJAX.DTO.Administracion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploAJAX.Contracts.Administracion
{
    interface IEstudianteService
    {

        IList<String> SaveInfo(EstudianteDTO objDTO);
        IList<String> ListInfo();
        IList<String> SearchInfo(String documento);
        IList<String> DeleteInfo(int id);
        IList<String> LoadDepartamento();
        IList<String> LoadMunicipio(int departamento);
    }
}