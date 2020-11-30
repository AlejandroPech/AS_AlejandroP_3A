using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.QueryFilters;
using System.Linq;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IAnimalRepository:IRepository<Animal>
    {
        public IQueryable<Animal> GetAnimals(AnimalQueryFilter filter);
    }
}
