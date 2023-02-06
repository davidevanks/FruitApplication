using System.Threading.Tasks;
using System.Collections.Generic;
using Entities;

namespace DataAccess.Repository
{
    public interface IFruitRepository
    {
        Task<IEnumerable<FruitDTO>> FindAll();
        Task<FruitDTO> FindById(long id);
        Task<FruitDTO> Save(FruitDTO fruitDTO);
        Task<FruitDTO> Update(long id, FruitDTO fruitDTO);
        Task<bool> Delete(long id);
    }
}
