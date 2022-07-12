using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiosMQ
{
    public class CondominiosDAO
    {
        private string conn;
        public CondominiosDAO()
        {
            conn = "Server=tcp:proy-gest-cond.database.windows.net,1433;Initial Catalog=db_gestion_condominios;Persist Security Info=False;User ID=fanampa;Password=Contra123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public Reserva RegistrarReserva(Reserva reserva)
        {
            var query = "INSERT INTO Reserva (FechaReserva,HoraInicio,HoraFin,IdAreaComun,IdInquilino,usuariocreacion,fechacreacion)" +
                "VALUES (@FechaReserva,@HoraInicio,@HoraFin,@IdAreaComun,@IdInquilino,@usuariocreacion,@fechacreacion)" +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            var parameters = new DynamicParameters();
            parameters.Add("FechaReserva", DateTime.ParseExact(reserva.FechaReserva,"yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), DbType.Date);
            parameters.Add("HoraInicio", DateTime.ParseExact(reserva.HoraInicio, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DbType.Time);
            parameters.Add("HoraFin", DateTime.ParseExact(reserva.HoraFin, "HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture), DbType.Time);
            parameters.Add("IdAreaComun", reserva.IdAreaComun, DbType.Int32);
            parameters.Add("IdInquilino", reserva.IdInquilino, DbType.Int32);
            parameters.Add("usuariocreacion", 9999, DbType.Int32);
            parameters.Add("fechacreacion", DateTime.Now, DbType.Date);

            using (var connection = new SqlConnection(conn))
            {
                connection.Open();

                var id = connection.QuerySingle<int>(query, parameters);

                var createdReserva = new Reserva
                {
                    FechaReserva = reserva.FechaReserva,
                    HoraInicio = reserva.HoraInicio,
                    HoraFin = reserva.HoraFin,
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
