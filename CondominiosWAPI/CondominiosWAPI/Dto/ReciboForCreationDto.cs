using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Dto
{
    public class ReciboForCreationDto
    {
        public int idrecibo { get; set; }
        public DateTime FechaRecibo { get; set; }
        public string Periodo { get; set; }
        public decimal MontoTotalSoles { get; set; }
        public int IdPropietario { get; set; }
        public int IdInquilino { get; set; }
        public int IdDepartamento { get; set; }
        public int IdEstadoRecibo { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
