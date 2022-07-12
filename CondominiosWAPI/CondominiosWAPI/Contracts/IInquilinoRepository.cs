using CondominiosWAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CondominiosWAPI.Contracts
{
    public interface IInquilinoRepository
    {
        public Task<IEnumerable<Usuario>> GetInquilinos();
        public Task<Usuario> GetInquilino(int id);
        public Task<Usuario> GetInquilinoByName(string name);
    }
}
