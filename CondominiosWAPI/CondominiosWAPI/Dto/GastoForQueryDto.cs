using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Dto
{
    public class GastoForQueryDto
    {
        public int IdCondominio { get; set; }
        public int IdTorre { get; set; }
        public int IdDepartamento { get; set; }
        public int IdProveedor { get; set; }
        public DateTime FechaGasto { get; set; }
        public DateTime FechaVencimiento { get; set; }

    }
}
