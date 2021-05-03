using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventoryApi.Models
{
    [Table("Car", Schema = "challenge")]
    public partial class Car
    {
        public Car()
        {
            Inventory = new HashSet<Inventory>();
        }

        [Key]
        public int     Id { get; set; }
        public string   Make { get; set; }
        public string   Model { get; set; }
        public string   Series { get; set; }
        public int      Year { get; set; }
        public bool?     Active { get; set; }
        public string   Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime? Last_Updated_Date { get; set; }

        // navigation property
        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }
}
