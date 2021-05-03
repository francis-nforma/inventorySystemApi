using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using inventoryApi.Models.DTO;
using inventoryApi.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace inventoryApi.Models.DataManager
{
    public class InventoryDataManager : IDataRepository<Inventory, InventoryDTO>
    {
        readonly InventoryDbContext _inventoryDbContext;

        public InventoryDataManager(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<Inventory> Get(int dealerId, int carId)
        {
            _inventoryDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var inventory = await _inventoryDbContext.Inventories.SingleOrDefaultAsync(i => i.DealerId == dealerId && i.CarId == carId);

            if (inventory == null)
            {
                return null;
            }

            return inventory;
        }

        public async Task<IEnumerable<Inventory>> GetData()
        {
            return await _inventoryDbContext.Inventories.ToListAsync();
        }

        public Task<Inventory> Add(Inventory entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Inventory> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Inventory>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Update(Inventory inventory)
        {
            _inventoryDbContext.Entry(inventory).State = EntityState.Modified;
            await _inventoryDbContext.SaveChangesAsync();
        }
    }
}
