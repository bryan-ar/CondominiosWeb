using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Dto
{
    public class ReservaForCreationDto
    {
        public int idreserva { get; set; }
        public DateTime FechaReserva { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int IdAreaComun { get; set; }
        public int IdInquilino { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
