using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Models
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public int Idrol { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
