using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ejemploAJAX.DTO.Administracion
{
    public class UsuarioDTO
    {

        public int Id { get; set; }
        public String Usuario { get; set; }
        public String Password { get; set; }

        public UsuarioDTO(int id, String usuario, String password)
        {
            Id = id;
            Usuario = usuario;
            Password = password;
        }

    }
}