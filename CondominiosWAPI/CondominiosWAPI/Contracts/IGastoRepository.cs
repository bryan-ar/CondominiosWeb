using CondominiosWAPI.Dto;
using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IGastoRepository
    {
        public Task<Gasto> GetGasto(GastoForQueryDto filtros);
        public Task<Gasto> CreateGasto(GastoForCreationDto company);
        public IEnumerable<TipoGasto> GetTiposGasto();
        public TipoGasto GetTipoGasto(int id);
        public IEnumerable<TipoCalculo> GetTiposCalculo();
        public TipoCalculo GetTipoCalculo(int id);
    }
}
