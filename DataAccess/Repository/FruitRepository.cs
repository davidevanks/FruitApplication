using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class FruitRepository : IFruitRepository
    {

        private readonly FruitContext _db;

        public FruitRepository(FruitContext db)
        {
            _db = db;
        }

        public Task<bool> Delete(long id)
        {
            var fruit = _db.Fruits.FirstOrDefault(x=>x.Id==id);

            if (fruit==null)
            {
                return Task.FromResult(false);
            }
            else
            {
                _db.Fruits.Remove(fruit);
                _db.SaveChangesAsync();
                return Task.FromResult(true);
            }
        }

        public Task<IEnumerable<FruitDTO>> FindAll()
        {
            var Fruits = _db.Fruits.AsQueryable();
            

            var query = (from f in Fruits 
                         select new FruitDTO() { 
                                  Id=f.Id,
                                  Name=f.Name,
                                  Description=f.Description
                                       }).AsEnumerable();

            return Task.FromResult(query);
        }

        public Task<FruitDTO> FindById(long id)
        {
            var Fruits = _db.Fruits.AsQueryable();
            

            var query = (from f in Fruits
                         where f.Id==id
                         select new FruitDTO()
                         {
                             Id = f.Id,
                             Name = f.Name,
                             Description = f.Description
                         }).FirstOrDefault();

            return Task.FromResult(query);
        }

        public Task<FruitDTO> Save(FruitDTO fruitDTO)
        {
            

            Fruit f = new Fruit();
            f.Name = fruitDTO.Name;
            f.Description = fruitDTO.Description;
            f.Type = fruitDTO.Type;

            _db.Fruits.Add(f);
            _db.SaveChangesAsync();

            fruitDTO.Id = f.Id;
            fruitDTO.Type = (long)f.Type;
            return Task.FromResult(fruitDTO);
        }

        public Task<FruitDTO> Update(long id, FruitDTO fruitDTO)
        {
            var objFromDb = _db.Fruits.FirstOrDefault(s => s.Id == id);
            if (objFromDb != null)
            {
                objFromDb.Name = fruitDTO.Name;
                objFromDb.Description = fruitDTO.Description;
                objFromDb.Type = 1;
                _db.Fruits.Update(objFromDb);
                _db.SaveChangesAsync();
            }
            else
            {
                fruitDTO= null;
            }

          
            return Task.FromResult(fruitDTO); 
        }
    }
}
