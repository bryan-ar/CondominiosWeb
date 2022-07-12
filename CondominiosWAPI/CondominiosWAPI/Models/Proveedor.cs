using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Models
{
    public class Proveedor
    {
        public int idproveedor { get; set; }
        public string RazonSocial { get; set; }
        public int IdTipoDocumento { get; set; }
        public string tipoDocumento { get; set; }
        public string nrodocumento { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }
    }
}
