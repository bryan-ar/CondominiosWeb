using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IAreaRepository
    {
        public Task<IEnumerable<TipoArea>> GetTiposArea();
        public Task<TipoArea> GetTipoArea(int id);
        public Task<IEnumerable<AreaComun>> GetAreasComunes();
        public Task<AreaComun> GetAreaComun(int id);
        public Task<IEnumerable<AreaComun>> GetAreasComunesByTipoArea(int idTipoArea);
    }
}
