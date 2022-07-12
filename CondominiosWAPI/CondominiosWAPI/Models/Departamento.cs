using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Models
{
    public class Departamento
    {
        public int iddepartamento { get; set; }
        public int NumDepartamento { get; set; }
        public int IdTorre { get; set; }
        public int NroPiso { get; set; }
        public long Area { get; set; }
        public int NroHabitaciones { get; set; }
        public int NroBanios { get; set; }
        public int Estado { get; set; }
        public int IdPropietario { get; set; }
        public int IdInquilino { get; set; }
        public int BloqueoMorosidad { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
