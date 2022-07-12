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
    public class TorreRepository : ITorreRepository
    {
        private readonly DapperContext _context;
        public TorreRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Torre>> GetTorres()
        {
            var query = "SELECT * FROM Torre";

            using (var connection = _context.CreateConnection())
            {
                var torres = await connection.QueryAsync<Torre>(query);
                return torres.ToList();
            }
        }

        public async Task<Torre> GetTorre(int id)
        {
            var query = "SELECT * FROM Torre WHERE idtorre = @Id";
            using (var connection = _context.CreateConnection())
            {
                var torre = await connection.QuerySingleOrDefaultAsync<Torre>(query, new { id });
                return torre;
            }
        }

        public async Task<IEnumerable<Torre>> GetTorresByCondominio(int idCondominio)
        {
            var query = "SELECT * FROM Torre WHERE idCondominio = @IdCondominio";
            using (var connection = _context.CreateConnection())
            {
                var torres = await connection.QueryAsync<Torre>(query, new { IdCondominio = idCondominio });
                return torres.ToList();
            }
        }
    }
}
