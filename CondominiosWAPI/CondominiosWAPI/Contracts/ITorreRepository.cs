using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface ITorreRepository
    {
        public Task<IEnumerable<Torre>> GetTorres();
        public Task<Torre> GetTorre(int id);
        public Task<IEnumerable<Torre>> GetTorresByCondominio(int idCondominio);
    }
}
