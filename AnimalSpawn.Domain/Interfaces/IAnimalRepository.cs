using AnimalSpawn.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> GetAnimals();
        Task<Animal> GetAnimal(int id);
        Task AddAnimal(Animal animal);
    }
}
