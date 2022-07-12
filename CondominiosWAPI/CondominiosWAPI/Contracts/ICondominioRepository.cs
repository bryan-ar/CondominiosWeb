using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface ICondominioRepository
    {
        public Task<IEnumerable<Condominio>> GetCondominios();
        public Task<Condominio> GetCondominio(int id);
    }
}
