using DataAccess.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
   public  class IBLFruit
    {
        private readonly IFruitRepository _fruitRepository;

        public IBLFruit(IFruitRepository fruitRepository)
        {
            _fruitRepository = fruitRepository;
            AddTestData();
        }

        public Task<IEnumerable<FruitDTO>> FindAll()
        {
           
           return _fruitRepository.FindAll();
        }

        public Task<FruitDTO> Update(long id, FruitDTO fruitDTO)
        {
            return _fruitRepository.Update(id,fruitDTO);
        }

        public Task<FruitDTO> FindById(long id)
        {
            return _fruitRepository.FindById(id);
        }

        public Task<FruitDTO> Save(FruitDTO fruit)
        {
            return _fruitRepository.Save(fruit);
        }

        public Task<bool> Delete(long id)
        {
            return _fruitRepository.Delete(id);
        }

        private  void AddTestData()
        {
            var f = new FruitDTO
            {
                Type = CreateFruitType().Id,
                Name = "Naranja",
                Description = "Naranja de Nicaragua"
                
            };

            _fruitRepository.Save(f);
        }

    private static FruitTypeDTO CreateFruitType()
    {
        return new FruitTypeDTO
        {
            Id = 1,
            Name = "Citric",
            Description = "Like oranges",
        };
    }
}
}
