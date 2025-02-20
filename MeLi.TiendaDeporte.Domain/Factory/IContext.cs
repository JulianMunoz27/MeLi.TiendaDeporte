using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeLi.TiendaDeporte.Domain.Factory
{
    public interface IContext : IUnitOfWork, IDisposable
    {
    }
}
