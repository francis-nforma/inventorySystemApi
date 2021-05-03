using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace inventoryApi.Models.Repository
{
    public interface IDataRepository<TEntity, TDto>
    {
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
        //Task GetDTO(int id);
        Task<TEntity> Add(TEntity entity);
        Task Delete(int id);
        Task Update(TEntity entity);

        Task<TEntity> Get(int id, int id2);
        Task<IEnumerable<TEntity>> GetData();
    }
}
