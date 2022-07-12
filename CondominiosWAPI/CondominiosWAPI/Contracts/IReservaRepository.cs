using CondominiosWAPI.Dto;
using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IReservaRepository
    {
        public Task<Reserva> GetReserva(int id);
        public Task<Reserva> CreateReserva(ReservaForCreationDto reserva);
    }
}
