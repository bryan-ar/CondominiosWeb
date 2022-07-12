using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Dto
{
    public class ReservaForQueryDto
    {
        public DateTime FechaReserva { get; set; }
        public int IdTipoArea { get; set; }
        public int IdAreaComun { get; set; }
        public int IdInquilino { get; set; }
    }
}
