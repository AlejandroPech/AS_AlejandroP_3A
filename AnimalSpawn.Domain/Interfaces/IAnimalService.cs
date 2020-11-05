using AnimalSpawn.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AnimalSpawn.Domain.Interfaces
{
    public interface IAnimalService
    {
        Task AddAnimal(Animal animal);
        Task DeleteAnimal(int id);
        IEnumerable<Animal> GetAnimals();
        Task<Animal> GetAnimal(int id);
        void UpdateAnimal(Animal animal);
    }
}
