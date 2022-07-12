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
    public class GastoRepository : IGastoRepository
    {
        private readonly DapperContext _context;
        private List<TipoGasto> tiposGasto = new List<TipoGasto>();
        private List<TipoCalculo> tiposCalculo = new List<TipoCalculo>();

        public GastoRepository(DapperContext context)
        {
            _context = context;
            tiposGasto.Add(new TipoGasto { idGasto = 1, Descripcion = "Común" });
            tiposGasto.Add(new TipoGasto { idGasto = 2, Descripcion = "Individual" });

            tiposCalculo.Add(new TipoCalculo { idTipoCalculo = 1, Descripcion = "Área" });
            tiposCalculo.Add(new TipoCalculo { idTipoCalculo = 2, Descripcion = "Departamento" });
        }

        public async Task<Gasto> GetGasto(GastoForQueryDto filtros)
        {
            var query = "Select * From Gasto Where IdCondominio = @IdCondominio And IdTorre = @IdTorre And IdDepartamento = @IdDepartamento" +
                " And IdProveedor = @IdProveedor And FechaGasto = @FechaGasto And FechaVencimiento = @FechaVencimiento";
            using (var connection = _context.CreateConnection())
            {
                var company = await connection.QuerySingleOrDefaultAsync<Gasto>(query, 
                    new {
                        IdCondominio = filtros.IdCondominio,
                        IdTorre = filtros.IdTorre,
                        IdDepartamento = filtros.IdDepartamento,
                        IdProveedor = filtros.IdProveedor,
                        FechaGasto = filtros.FechaGasto,
                        FechaVencimiento = filtros.FechaVencimiento
                    });

                company.TipoGastoDesc = tiposGasto.Where(x => x.idGasto == company.TipoGasto).FirstOrDefault().Descripcion;
                company.TipoCalculoDesc = tiposCalculo.Where(x => x.idTipoCalculo == company.TipoCalculo).FirstOrDefault().Descripcion;

                return company;
            }
        }

        public async Task<Gasto> CreateGasto(GastoForCreationDto gasto)
        {
            var query = "INSERT INTO Gasto (Descripcion,IdProveedor,FechaGasto,FechaVencimiento,TipoGasto,TipoCalculo,IdCondominio,IdTorre,IdDepartamento,montosoles,usuariocreacion,fechacreacion)" +
                "VALUES (@Descripcion,@IdProveedor,@FechaGasto,@FechaVencimiento,@TipoGasto,@TipoCalculo,@IdCondominio,@IdTorre,@IdDepartamento,@montosoles,@usuariocreacion,@fechacreacion)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("Descripcion", gasto.Descripcion, DbType.String);
            parameters.Add("IdProveedor", gasto.IdProveedor, DbType.Int32);
            parameters.Add("FechaGasto", gasto.FechaGasto, DbType.Date);
            parameters.Add("FechaVencimiento", gasto.FechaVencimiento, DbType.Date);
            parameters.Add("TipoGasto", gasto.TipoGasto, DbType.Int32);
            parameters.Add("TipoCalculo", gasto.TipoCalculo, DbType.Int32);
            parameters.Add("IdCondominio", gasto.IdCondominio, DbType.Int32);
            parameters.Add("IdTorre", gasto.IdTorre, DbType.Int32);
            parameters.Add("IdDepartamento", gasto.IdDepartamento, DbType.Int32);
            parameters.Add("montosoles", gasto.montosoles, DbType.Decimal);
            parameters.Add("usuariocreacion", gasto.usuariocreacion, DbType.Int32);
            parameters.Add("fechacreacion", gasto.fechacreacion, DbType.Date);
            
            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);

                var createdGasto = new Gasto
                {
                    idgasto = id,
                    Descripcion = gasto.Descripcion,
                    IdProveedor = gasto.IdProveedor,
                    FechaGasto = gasto.FechaGasto,
                    FechaVencimiento = gasto.FechaVencimiento,
                    TipoGasto = gasto.TipoGasto,
                    TipoCalculo = gasto.TipoCalculo,
                    IdCondominio = gasto.IdCondominio,
                    IdTorre = gasto.IdTorre,
                    IdDepartamento = gasto.IdDepartamento,
                    montosoles = gasto.montosoles,
                    usuariocreacion = gasto.usuariocreacion,
                    fechacreacion = gasto.fechacreacion,
                    usuariomodificacion = gasto.usuariomodificacion,
                    fechamodificacion = gasto.fechamodificacion
                };

                return createdGasto;
            }
        }

        public IEnumerable<TipoGasto> GetTiposGasto()
        {
            return tiposGasto;
        }

        public TipoGasto GetTipoGasto(int id)
        {
            return tiposGasto.Where(x => x.idGasto == id).FirstOrDefault();
        }

        public IEnumerable<TipoCalculo> GetTiposCalculo()
        {
            return tiposCalculo;
        }

        public TipoCalculo GetTipoCalculo(int id)
        {
            return tiposCalculo.Where(x => x.idTipoCalculo == id).FirstOrDefault();
        }
    }
}
