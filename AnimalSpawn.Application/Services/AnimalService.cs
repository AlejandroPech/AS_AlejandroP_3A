﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
namespace AnimalSpawn.Application.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AnimalService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }


        public async Task AddAnimal(Animal animal)
        {
            Expression<Func<Animal,bool>> expressionAnimal = item => item.Name == animal.Name;

            var animals = await _unitOfWork.AnimalRepository.FindByCondition(expressionAnimal);

            if (animals.Any(item => item.Name == animal.Name))
                throw new Exception("This animal name already exist.");

            if (animal?.EstimatedAge > 0 && (animal?.Weight <= 0 || animal?.Height <= 0))
                throw new Exception("The height and weight should be greater than zero.");

            var older = DateTime.Now - (animal?.CaptureDate ?? DateTime.Now);

            if (older.TotalDays > 45)
                throw new Exception("The animal's capture date is older than 45 days");

            if (animal.RfidTag != null)
            {
                Expression<Func<RfidTag, bool>> expressionTag = tag => tag.Tag == animal.RfidTag.Tag;
                var tags = await _unitOfWork.RfifTagRepository.FindByCondition(expressionTag);
                if (tags.Any())
                    throw new Exception("This animal's tag rfid is already exist");
            }                  

            await _unitOfWork.AnimalRepository.Add(animal);
        }

        public async Task DeleteAnimal(int id)
        {
            await _unitOfWork.AnimalRepository.Delete(id);
        }

        public async Task<Animal> GetAnimal(int id)
        {
            return await _unitOfWork.AnimalRepository.GetById(id);
        }

        public async Task<IEnumerable<Animal>> GetAnimals()
        {
            return await _unitOfWork.AnimalRepository.GetAll();
        }

        public async Task UpdateAnimal(Animal animal)
        {
            await _unitOfWork.AnimalRepository.Update(animal);
        }
    }
}
