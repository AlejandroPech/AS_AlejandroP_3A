using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSpawn.Infraestructure.Repositories
{
    public class AnimalRepository:IAnimalRepository
    {
        private readonly AnimalSpawnContext context;
        public AnimalRepository(AnimalSpawnContext context)
        {
            this.context = context;
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await context.Animal.FirstOrDefaultAsync(x => x.Id == id) ?? new Animal();
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await context.Animal.ToListAsync();
        }

        public async Task AddAnimal(Animal animal)
        {
            context.Animal.Add(animal);
            await context.SaveChangesAsync();
        }
    }
}
