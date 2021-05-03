using System.Collections.Generic;

namespace inventoryApi.Models.DTO
{
    public class DealerDTO
    {
        public DealerDTO()
        {
        }

        public int    Id { get; set; }
        public string Dealer_Name { get; set; }
        public string Address_Line1 { get; set; }
        public string Address_Line2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public int    Postcode { get; set; }
        public string Contact_Number { get; set; }

        public ICollection<CarDTO> Cars { get; set; }
    }
}
