using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Models
{
    public class Gasto
    {
        public int idgasto { get; set; }
        public string Descripcion { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaGasto { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int TipoGasto { get; set; }
        public string TipoGastoDesc { get; set; }
        public int TipoCalculo { get; set; }
        public string TipoCalculoDesc { get; set; }
        public int IdCondominio { get; set; }
        public int IdTorre { get; set; }
        public int IdDepartamento { get; set; }
        public decimal montosoles { get; set; }
        public int usuariocreacion { get; set; }
        public DateTime fechacreacion { get; set; }
        public int usuariomodificacion { get; set; }
        public DateTime fechamodificacion { get; set; }

    }
}
