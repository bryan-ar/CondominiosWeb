using CondominiosWAPI.Dto;
using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IReciboRepository
    {
        public Task<IEnumerable<Recibo>> GetRecibos(ReciboForQueryDto filtros);
        public Task<Recibo> GetRecibo(int id);
        public Task<Recibo> CreateRecibo(ReciboForCreationDto reserva);
        public Task PagarRecibo(ReciboForPaymentDto reserva);
        public Task<IEnumerable<EstadoRecibo>> GetEstadosRecibo();
        public Task<EstadoRecibo> GetEstadoRecibo(int id);

    }
}
