using CondominiosWAPI.Context;
using CondominiosWAPI.Contracts;
using CondominiosWAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly DapperContext _context;
        public ProveedorRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> GetProveedores()
        {
            var query = "SELECT * FROM Proveedor";

            using (var connection = _context.CreateConnection())
            {
                var proveedores = await connection.QueryAsync<Proveedor>(query);
                return proveedores.ToList();
            }
        }

        public async Task<Proveedor> GetProveedor(int id)
        {
            var query = "SELECT * FROM Proveedor WHERE idproveedor = @Id";
            using (var connection = _context.CreateConnection())
            {
                var proveedor = await connection.QuerySingleOrDefaultAsync<Proveedor>(query, new { id });
                return proveedor;
            }
        }

        public async Task<IEnumerable<Proveedor>> GetProveedoresByName(string name)
        {
            var query = "SELECT *, tipoDocumento = td.Nombre FROM Proveedor p inner join tipodocumento td on p.IdTipoDocumento = td.idtipodocumento " +
                "WHERE p.RazonSocial Like @RazonSocial";
            using (var connection = _context.CreateConnection())
            {
                var proveedores = await connection.QueryAsync<Proveedor>(query, new { RazonSocial = "%" + name + "%" });
                return proveedores.ToList();
            }
        }
    }
}
