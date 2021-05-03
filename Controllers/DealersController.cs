using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using inventoryApi.Models;
using inventoryApi.Models.DTO;
using inventoryApi.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace inventoryApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DealersController : ControllerBase
    {
        private readonly IDataRepository<Dealer, DealerDTO> _dataRepository;

        public DealersController(IDataRepository<Dealer, DealerDTO> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        //GET api/dealers/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> Get(int id)
        {
            var dealer = await _dataRepository.Get(id);
            if (dealer == null)
            {
                return NotFound("dealer not found.");
            }
            return Ok(dealer);
        }

        //GET api/dealers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetAll()
        {
            var dealers = await _dataRepository.GetAll();
            return Ok(dealers);
        }

        // POST api/dealers
        [HttpPost]
        public async Task<ActionResult<Dealer>> Post([FromBody] Dealer dealer)
        {
            var newDealer = await _dataRepository.Add(dealer);
            return CreatedAtAction(nameof(Get), new { id = newDealer.Id }, newDealer);
        }

        // PUT api/dealers/1
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Dealer dealer)
        {
            if (id != dealer.Id)
            {
                return BadRequest();
            }
            await _dataRepository.Update(dealer);
            return NoContent();
        }

        // DELETE api/dealers/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var dealerToInactivate = await _dataRepository.Get(id);
            if (dealerToInactivate == null)
            {
                return NotFound();
            }
            // set dealer record to inactive
            dealerToInactivate.Active = false;
            await Put(id, dealerToInactivate);
            return NoContent();
        }
    }
}