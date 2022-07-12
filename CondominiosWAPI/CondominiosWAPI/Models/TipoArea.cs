using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Models
{
    public class TipoArea
    {
        public int idtipoarea { get; set; }
        public string Nombre { get; set; }
        public string TipoReserva { get; set; }
        public string HoraApertura { get; set; }
        public string HoraCierre { get; set; }
        public int CantidadMaxima { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
