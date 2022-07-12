using CondominiosWAPI.Context;
using CondominiosWAPI.Contracts;
using CondominiosWAPI.Dto;
using CondominiosWAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly DapperContext _context;
        public ReservaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Reserva> GetReserva(int id)
        {
            var query = "Select * From Reserva Where Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                var reserva = await connection.QuerySingleOrDefaultAsync<Reserva>(query, new { Id = id });
                return reserva;
            }
        }

        public async Task<Reserva> CreateReserva(ReservaForCreationDto reserva)
        {
            var query = "INSERT INTO Reserva (FechaReserva,HoraInicio,HoraFin,IdAreaComun,IdInquilino,usuariocreacion,fechacreacion)" +
                "VALUES (@FechaReserva,@HoraInicio,@HoraFin,@IdAreaComun,@IdInquilino,@usuariocreacion,@fechacreacion)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("FechaReserva", reserva.FechaReserva, DbType.Date);
            parameters.Add("HoraInicio", TimeSpan.Parse(reserva.HoraInicio), DbType.Time);
            parameters.Add("HoraFin", TimeSpan.Parse(reserva.HoraFin), DbType.Time);
            parameters.Add("IdAreaComun", reserva.IdAreaComun, DbType.Int32);
            parameters.Add("IdInquilino", reserva.IdInquilino, DbType.Int32);
            parameters.Add("usuariocreacion", reserva.usuariocreacion, DbType.Int32);
            parameters.Add("fechacreacion", reserva.fechacreacion, DbType.Date);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdReserva = new Reserva
                {
                    idreserva = id,
                    FechaReserva = reserva.FechaReserva,
                    HoraInicio = TimeSpan.Parse(reserva.HoraInicio),
                    HoraFin = TimeSpan.Parse(reserva.HoraFin),
                    IdAreaComun = reserva.IdAreaComun,
                    IdInquilino = reserva.IdInquilino,
                    usuariocreacion = reserva.usuariocreacion,
                    fechacreacion = reserva.fechacreacion
                };

                return createdReserva;
            }
        }
    }
}
