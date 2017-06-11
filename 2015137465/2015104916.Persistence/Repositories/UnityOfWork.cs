using _2015104916.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Persistence.Repositories
{
    public class UnityOfWork:IUnityofWork
    {
        private readonly _2015137465DbContext _Context;

        public IAsientoRepository Asientos { get; private set; }
        public ICarroRepository Carros { get; private set; }
        public ICinturonRepository Cinturones { get; private set; }
        public IEnsambladoraRepository Ensambladoras { get; private set; }
        public ILlantaRepository Llantas { get; private set; }
        public IParabrisasRepository Parabrisas { get; private set; }
        public IPropietarioRepository Propietarios { get; private set; }
        public IVolanteRepository Volantes { get; private set; }
        

        public UnityOfWork(_2015137465DbContext context)
        {
            _Context = context;
            Asientos = new AsientoRepository(_Context);
            Carros = new CarroRepository(_Context);
            Cinturones = new CinturonRepository(_Context);
            Ensambladoras = new EnsambladoraRepository(_Context);
            Llantas = new LlantaRepository(_Context);
            Parabrisas = new ParabrisasRepository(_Context);
            Propietarios = new PropietarioRepository(_Context);
            Volantes = new VolanteRepository(_Context);
            
        }


        public void Dispose()
        {
            _Context.Dispose();
        }

        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.
        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
