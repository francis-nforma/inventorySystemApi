using System;
using System.Collections.Generic;

namespace inventoryApi.Models.DTO
{
    public class CarDTO
    {
        public int      Id { get; set; }
        public string   Make { get; set; }
        public string   Model { get; set; }
        public string   Series { get; set; }
        public int      Year { get; set; }
        //public DateTime Created_Date { get; set; }
        //public DateTime Created_By { get; set; }
        //public DateTime Last_Updated_Date { get; set; }

        public ICollection<DealerDTO> Dealers { get; set; }
    }
}
