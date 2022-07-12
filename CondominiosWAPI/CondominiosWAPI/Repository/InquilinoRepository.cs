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
    public class InquilinoRepository : IInquilinoRepository
    {
        private readonly DapperContext _context;
        public InquilinoRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetInquilinos()
        {
            var query = "SELECT * FROM Usuario";

            using (var connection = _context.CreateConnection())
            {
                var usuarios = await connection.QueryAsync<Usuario>(query);
                return usuarios.ToList();
            }
        }

        public async Task<Usuario> GetInquilino(int id)
        {
            var query = "SELECT * FROM Usuario WHERE idusuario = @Id";
            using (var connection = _context.CreateConnection())
            {
                var usuario = await connection.QuerySingleOrDefaultAsync<Usuario>(query, new { id });
                return usuario;
            }
        }

        public async Task<Usuario> GetInquilinoByName(string name)
        {
            var query = "SELECT * FROM Usuario WHERE Nombres + ' ' + Apellidos Like @NombreCompleto";
            using (var connection = _context.CreateConnection())
            {
                var usuario = await connection.QueryAsync<Usuario>(query, new { NombreCompleto = "%" + name + "%" });
                return usuario.FirstOrDefault();
            }
        }
    }
}
