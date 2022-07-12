using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Models
{
    public class AreaComun
    {
        public int idareacomun { get; set; }
        public string Nombre { get; set; }
        public int IdTipoArea { get; set; }
        public int IdCondominio { get; set; }
        public int IdTorre { get; set; }
        public int NroPiso { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
