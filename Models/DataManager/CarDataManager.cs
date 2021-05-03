using System.Collections.Generic;
using inventoryApi.Models.Repository;
using inventoryApi.Models.DTO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace inventoryApi.Models.DataManager
{
    public class CarDataManager : IDataRepository<Car, CarDTO>
    {
        readonly InventoryDbContext _inventoryDbContext;

        public CarDataManager(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<Car> Get(int id)
        {
            _inventoryDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var car = await _inventoryDbContext.Cars.FindAsync(id);

            if (car == null)
            {
                return null;
            }

            //_inventoryDbContext.Entry(car)
            //    .Collection(c => c.Inventory)
            //    .Load();

            return car;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _inventoryDbContext.Cars.ToListAsync();
        }

        //public Task GetDTO(int id)
        //{
        //    throw new System.NotImplementedException();
        //}


        public async Task<Car> Add(Car car)
        {
            _inventoryDbContext.Cars.Add(car);
            await _inventoryDbContext.SaveChangesAsync();
            return car;
        }

        public async Task Delete(int id)
        {
            var carToDelete = await _inventoryDbContext.Cars.FindAsync(id);
            _inventoryDbContext.Remove(carToDelete);
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task Update(Car car)
        {
            _inventoryDbContext.Entry(car).State = EntityState.Modified;
            await _inventoryDbContext.SaveChangesAsync();
        }

        public Task<Car> Get(int id, int id2)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}
