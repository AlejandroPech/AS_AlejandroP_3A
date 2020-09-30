using AnimalSpawn.Domain.DTOs;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalSpawn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository _repository;
        private readonly IMapper _mapper;
        public AnimalController(IAnimalRepository repository, IMapper _mapper)
        {
            _repository = repository;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {   
            var animals =  await _repository.GetAnimals();            
            var animalsDto = _mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalResponseDto>>(animals);

            return Ok(animalsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await _repository.GetAnimal(id);            
            var animalDto = _mapper.Map<Animal, AnimalResponseDto>(animal);

            return Ok(animalDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnimalRequestDto animalDto)
        {
            var animal = _mapper.Map<AnimalRequestDto, Animal>(animalDto);
            await _repository.AddAnimal(animal);            
            var animalresponseDto = _mapper.Map<Animal, AnimalResponseDto>(animal);

            return Ok(animalresponseDto);  
        }

    }
}
