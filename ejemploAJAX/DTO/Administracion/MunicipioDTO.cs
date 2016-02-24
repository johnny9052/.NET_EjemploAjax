using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploAJAX.DTO.Administracion
{
    public class MunicipioDTO
    {

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int IdDepartamento { get; set; }

        public MunicipioDTO(int id, String nombre, String descripcion, int idDepartamento)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            IdDepartamento = idDepartamento;
        }

    }
}