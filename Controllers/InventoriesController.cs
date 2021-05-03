using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using inventoryApi.Models;
using inventoryApi.Models.DTO;
using inventoryApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace inventoryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoriesController : ControllerBase
    {
        private readonly IDataRepository<Inventory, InventoryDTO> _dataRepository;

        public InventoriesController(IDataRepository<Inventory, InventoryDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET api/inventories/1
        [HttpGet("{dealerId}/{carId}")]
        public async Task<ActionResult<Inventory>> Get(int dealerId, int carId)
        {
            var inventory = await _dataRepository.Get(dealerId, carId);
            if (inventory == null)
            {
                return NotFound("inventory record not found.");
            }
            return Ok(inventory);
        }

        //GET api/inventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetData()
        {
            var dealers = await _dataRepository.GetData();
            return Ok(dealers);
        }

        // PUT api/inventories/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Inventory inventory)
        {
            if (id != inventory.Id)
            {
                return BadRequest();
            }
            await _dataRepository.Update(inventory);
            return NoContent();
        }
    }
}
