using _2015104916.Entities.Entities;
using _2015104916.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015104916.Persistence.Repositories
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(_2015137465DbContext context) : base(context)
        {

        }
    }
}
