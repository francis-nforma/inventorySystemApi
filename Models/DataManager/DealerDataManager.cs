using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using inventoryApi.Models.DTO;
using inventoryApi.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace inventoryApi.Models.DataManager
{
    public class DealerDataManager : IDataRepository<Dealer, DealerDTO>
    {
        readonly InventoryDbContext _inventoryDbContext;

        public DealerDataManager(InventoryDbContext inventoryDbContext)
        {
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<Dealer> Get(int id)
        {
            _inventoryDbContext.ChangeTracker.LazyLoadingEnabled = false;

            var dealer = await _inventoryDbContext.Dealers.FindAsync(id);

            if (dealer == null)
            {
                return null;
            }

            //_inventoryDbContext.Entry(dealer)
            //    .Collection(c => c.Inventory)
            //    .Load();

            return dealer;
        }

        public async Task<IEnumerable<Dealer>> GetAll()
        {
            return await _inventoryDbContext.Dealers.ToListAsync();
        }

        public async Task<Dealer> Add(Dealer car)
        {
            _inventoryDbContext.Dealers.Add(car);
            await _inventoryDbContext.SaveChangesAsync();
            return car;
        }

        public async Task Delete(int id)
        {
            var dealerToInactivate = await _inventoryDbContext.Dealers.FindAsync(id);
            // note: we dont delete record, only set active flag to false
            dealerToInactivate.Active = false;
            _inventoryDbContext.Entry(dealerToInactivate).State = EntityState.Modified;
            await _inventoryDbContext.SaveChangesAsync();
        }

        public async Task Update(Dealer dealer)
        {
            _inventoryDbContext.Entry(dealer).State = EntityState.Modified;
            await _inventoryDbContext.SaveChangesAsync();
        }

        public Task<Dealer> Get(int id, int id2)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Dealer>> GetData()
        {
            throw new System.NotImplementedException();
        }
    }
}
