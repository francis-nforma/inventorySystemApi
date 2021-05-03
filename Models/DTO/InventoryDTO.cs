using System;
using System.Collections.Generic;

namespace inventoryApi.Models.DTO
{
    public class InventoryDTO
    {
        public InventoryDTO()
        {
        }

        public int Id { get; set; }
        public int CarId { get; set; }
        public int DealerId { get; set; }
        public int Quantity { get; set; }

        //public ICollection<DealerDTO> Dealers { get; set; }
        //public ICollection<CarDTO> Cars { get; set; }
    }
}
