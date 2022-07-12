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
    public class ReciboRepository: IReciboRepository
    {
        private readonly DapperContext _context;
        public ReciboRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recibo>> GetRecibos(ReciboForQueryDto filtros)
        {
            var query = "Select * From Recibo Where FechaRecibo = @FechaRecibo And IdInquilino = @IdInquilino" +
                " And IdDepartamento = @IdDepartamento And IdEstadoRecibo = @IdEstadoRecibo";
            using (var connection = _context.CreateConnection())
            {
                var recibos = await connection.QueryAsync<Recibo>(query,
                    new
                    {
                        FechaRecibo = filtros.FechaRecibo,
                        IdInquilino = filtros.IdInquilino,
                        IdDepartamento = filtros.IdDepartamento,
                        IdEstadoRecibo = filtros.IdEstadoRecibo
                    });
                return recibos.ToList();
            }
        }

        public async Task<Recibo> GetRecibo(int id)
        {
            var query = "Select * From Recibo Where IdRecibo = @Id";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Recibo>(query, new { Id = id });
                return company;
            }
        }

        public async Task<Recibo> CreateRecibo(ReciboForCreationDto recibo)
        {
            var query = "INSERT INTO Recibo (FechaRecibo,Periodo,MontoTotalSoles,IdPropietario,IdInquilino,IdDepartamento,IdEstadoRecibo,usuariocreacion,fechacreacion)" +
                "VALUES (@FechaRecibo,@Periodo,@MontoTotalSoles,@IdPropietario,@IdInquilino,@IdDepartamento,@IdEstadoRecibo,@usuariocreacion,@fechacreacion)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("FechaRecibo", recibo.FechaRecibo, DbType.Date);
            parameters.Add("Periodo", recibo.Periodo, DbType.String);
            parameters.Add("MontoTotalSoles", recibo.MontoTotalSoles, DbType.Decimal);
            parameters.Add("IdPropietario", recibo.IdPropietario, DbType.Int32);
            parameters.Add("IdInquilino", recibo.IdInquilino, DbType.Int32);
            parameters.Add("IdDepartamento", recibo.IdDepartamento, DbType.Int32);
            parameters.Add("IdEstadoRecibo", recibo.IdEstadoRecibo, DbType.Int32);
            parameters.Add("usuariocreacion", recibo.usuariocreacion, DbType.Int32);
            parameters.Add("fechacreacion", recibo.fechacreacion, DbType.Date);

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdRecibo = new Recibo
                {
                    idrecibo = id,
                    FechaRecibo = recibo.FechaRecibo,
                    Periodo = recibo.Periodo,
                    MontoTotalSoles = recibo.MontoTotalSoles,
                    IdPropietario = recibo.IdPropietario,
                    IdInquilino = recibo.IdInquilino,
                    IdDepartamento = recibo.IdDepartamento,
                    IdEstadoRecibo = recibo.IdEstadoRecibo,
                    usuariocreacion = recibo.usuariocreacion,
                    fechacreacion = recibo.fechacreacion
                };

                return createdRecibo;
            }
        }

        public async Task PagarRecibo(ReciboForPaymentDto recibo)
        {
            var query = "UPDATE Recibo SET IdEstadoRecibo = 2 WHERE idrecibo = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", recibo.idrecibo, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<IEnumerable<EstadoRecibo>> GetEstadosRecibo()
        {
            var query = "SELECT * FROM EstadoRecibo";

            using (var connection = _context.CreateConnection())
            {
                var estadosRecibo = await connection.QueryAsync<EstadoRecibo>(query);
                return estadosRecibo.ToList();
            }
        }

        public async Task<EstadoRecibo> GetEstadoRecibo(int id)
        {
            var query = "SELECT * FROM EstadoRecibo WHERE idestadorecibo = @Id";
            using (var connection = _context.CreateConnection())
            {
                var estadoRecibo = await connection.QuerySingleOrDefaultAsync<EstadoRecibo>(query, new { id });
                return estadoRecibo;
            }
        }
    }
}
