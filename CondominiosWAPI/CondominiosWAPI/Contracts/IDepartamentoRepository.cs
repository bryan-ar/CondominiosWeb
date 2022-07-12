using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IDepartamentoRepository
    {
        public Task<IEnumerable<Departamento>> GetDepartamentos();
        public Task<Departamento> GetDepartamento(int id);
        public Task<IEnumerable<Departamento>> GetDepartamentosByTorre(int idTorre);
    }
}
