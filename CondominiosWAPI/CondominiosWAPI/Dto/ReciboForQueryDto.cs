using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Dto
{
    public class ReciboForQueryDto
    {
        public DateTime FechaRecibo { get; set; }
        public int IdInquilino { get; set; }
        public int IdDepartamento { get; set; }
        public int IdEstadoRecibo { get; set; }
    }
}
