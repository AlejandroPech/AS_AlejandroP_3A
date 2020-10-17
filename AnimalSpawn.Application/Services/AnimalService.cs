using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
namespace AnimalSpawn.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _repository;
        public AnimalService(IAnimalRepository repository)
        {
            this._repository = repository;
        }


        public async Task AddAnimal(Animal animal)
        {
            var animals = await _repository.GetAnimals();

            if (animals.Any(item => item.Name == animal.Name))
                throw new Exception("This animal name already exist.");

            if (animal?.EstimatedAge > 0 && (animal?.Weight <= 0 || animal?.Height <= 0))
                throw new Exception("The height and weight should be greater than zero.");

            var older = DateTime.Now - (animal?.CaptureDate ?? DateTime.Now);

            if (older.TotalDays > 45)
                throw new Exception("The animal's capture date is older than 45 days");

            await _repository.AddAnimal(animal);
        }

        public async Task<bool> DeleteAnimal(int id)
        {
            return await _repository.DeleteAnimal(id);
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _repository.GetAnimal(id);
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _repository.GetAnimals();
        }

        public async Task<bool> UpdateAnimal(Animal animal)
        {
            return await _repository.UpdateAnimal(animal);
        }
    }
}
