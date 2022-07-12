using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IProveedorRepository
    {
        public Task<IEnumerable<Proveedor>> GetProveedores();
        public Task<Proveedor> GetProveedor(int id);
        public Task<IEnumerable<Proveedor>> GetProveedoresByName(string name);
    }
}
