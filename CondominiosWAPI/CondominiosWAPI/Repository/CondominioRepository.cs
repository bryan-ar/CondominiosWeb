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
    public class CondominioRepository : ICondominioRepository
    {
        private readonly DapperContext _context;
        public CondominioRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Condominio>> GetCondominios()
        {
            var query = "SELECT * FROM Condominio";

            using (var connection = _context.CreateConnection())
            {
                var proveedores = await connection.QueryAsync<Condominio>(query);
                return proveedores.ToList();
            }
        }

        public async Task<Condominio> GetCondominio(int id)
        {
            var query = "SELECT * FROM Condominio WHERE idcondominio = @Id";
            using (var connection = _context.CreateConnection())
            {
                var proveedor = await connection.QuerySingleOrDefaultAsync<Condominio>(query, new { id });
                return proveedor;
            }
        }
    }
}
