using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.NavigationEntities;
using AnimalSpawn.Domain.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IAnimalService
    {
        Task AddAnimal(Animal animal);
        Task DeleteAnimal(int id);
        PagedList<Animal> GetAnimals(AnimalQueryFilter filter);
        Task<Animal> GetAnimal(int id);
        void UpdateAnimal(Animal animal);
    }
}
