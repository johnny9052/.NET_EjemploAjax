using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploAJAX.DTO.Administracion
{
    public class EstudianteDTO
    {

        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int Semestre { get; set; }
        public String Documento { get; set; }
        public int IdMunicipio { get; set; }

        public EstudianteDTO(int id, String nombre, String apellido, int semestre, String documento, int idMunicipio)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Semestre = semestre;
            Documento = documento;
            IdMunicipio = idMunicipio;
        }

    }
}