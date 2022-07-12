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
    public class AreaRepository: IAreaRepository
    {
        private readonly DapperContext _context;
        public AreaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TipoArea>> GetTiposArea()
        {
            var query = "SELECT idtipoarea, Nombre, TipoReserva, HoraApertura = Cast(HoraApertura As Varchar), HoraCierre = Cast(HoraCierre As Varchar),CantidadMaxima, usuariocreacion, fechacreacion, usuariomodificacion, fechamodificacion " +
                "FROM TipoArea";

            using (var connection = _context.CreateConnection())
            {
                var tiposArea = await connection.QueryAsync<TipoArea>(query);
                return tiposArea.ToList();
            }
        }

        public async Task<TipoArea> GetTipoArea(int id)
        {
            var query = "SELECT select idtipoarea, Nombre, TipoReserva, HoraApertura = Cast(HoraApertura As Varchar), HoraCierre = Cast(HoraCierre As Varchar),CantidadMaxima, usuariocreacion, fechacreacion, usuariomodificacion, fechamodificacion " +
                "FROM TipoArea WHERE idtipoarea = @Id";
            using (var connection = _context.CreateConnection())
            {
                var tipoArea = await connection.QuerySingleOrDefaultAsync<TipoArea>(query, new { id });
                return tipoArea;
            }
        }

        public async Task<IEnumerable<AreaComun>> GetAreasComunes()
        {
            var query = "SELECT * FROM AreaComun";

            using (var connection = _context.CreateConnection())
            {
                var areasComunes = await connection.QueryAsync<AreaComun>(query);
                return areasComunes.ToList();
            }
        }

        public async Task<AreaComun> GetAreaComun(int id)
        {
            var query = "SELECT * FROM AreaComun WHERE idareacomun = @Id";
            using (var connection = _context.CreateConnection())
            {
                var areaComun = await connection.QuerySingleOrDefaultAsync<AreaComun>(query, new { id });
                return areaComun;
            }
        }

        public async Task<IEnumerable<AreaComun>> GetAreasComunesByTipoArea(int idTorre)
        {
            var query = "SELECT * FROM AreaComun WHERE idtipoarea = @IdTorre";
            using (var connection = _context.CreateConnection())
            {
                var areasComunes = await connection.QueryAsync<AreaComun>(query, new { IdTorre = idTorre });
                return areasComunes.ToList();
            }
        }
    }
}
