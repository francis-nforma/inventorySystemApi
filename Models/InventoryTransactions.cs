using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventoryApi.Models
{
    [Table("InventoryTransactions", Schema = "challenge")]
    public class InventoryTransactions
    {
        [Key]
        public int      Id { get; set; }
        public int      CarId { get; set; }
        public int      DealerId { get; set; }
        public string   Event { get; set; }
        public int      quantity { get; set; }
        public string   Created_By { get; set; }
        public DateTime Created_Date { get; set; }

        public virtual Car Car { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
