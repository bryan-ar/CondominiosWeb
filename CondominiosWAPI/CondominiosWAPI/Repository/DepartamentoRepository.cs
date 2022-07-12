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
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly DapperContext _context;
        public DepartamentoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentos()
        {
            var query = "SELECT * FROM Departamento";

            using (var connection = _context.CreateConnection())
            {
                var departamentos = await connection.QueryAsync<Departamento>(query);
                return departamentos.ToList();
            }
        }

        public async Task<Departamento> GetDepartamento(int id)
        {
            var query = "SELECT * FROM Departamento WHERE iddepartamento = @Id";
            using (var connection = _context.CreateConnection())
            {
                var departamento = await connection.QuerySingleOrDefaultAsync<Departamento>(query, new { id });
                return departamento;
            }
        }

        public async Task<IEnumerable<Departamento>> GetDepartamentosByTorre(int idTorre)
        {
            var query = "SELECT * FROM Departamento WHERE idTorre = @IdTorre";
            using (var connection = _context.CreateConnection())
            {
                var departamentos = await connection.QueryAsync<Departamento>(query, new { IdTorre = idTorre });
                return departamentos.ToList();
            }
        }
    }
}
