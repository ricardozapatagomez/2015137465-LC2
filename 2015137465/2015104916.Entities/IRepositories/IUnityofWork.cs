using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Entities.IRepositories
{
    public interface IUnityofWork : IDisposable
    {

        IAsientoRepository Asientos { get; }
        ICarroRepository Carros { get; }
        ICinturonRepository Cinturones { get; }
        IEnsambladoraRepository Ensambladoras { get; }
        ILlantaRepository Llantas { get; }
        IParabrisasRepository Parabrisas { get; }
        IPropietarioRepository Propietarios { get; }
        IVolanteRepository Volantes { get; }
        void StateModified(object entity);
        int SaveChanges();
    }
}
