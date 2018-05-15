using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services
{
    public class Generate : ITransient, IScoped, ISingelton
    {
        private Guid _guid;

        public Generate()
        {
            _guid =  Guid.NewGuid();

        }

        public Guid GetGuid()
        {
            return _guid;
        }
    }
}
