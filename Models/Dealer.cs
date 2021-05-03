using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inventoryApi.Models
{
    [Table("Dealer", Schema = "challenge")]
    public partial class Dealer
    {
        public Dealer()
        {
            Inventory = new HashSet<Inventory>();
        }

        [Key]
        public int      Id { get; set; }
        public string   Dealer_Name {get; set;}
        public string   Address_Line1 { get; set; }
        public string   Address_Line2 { get; set; }
        public string   Address_Suburb { get; set; }
        public string   Address_State { get; set; }
        public int?     Address_Postcode { get; set; }
        public string   Contact_Number { get; set; }
        public bool?     Active { get; set; }
        public string   Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public DateTime? Last_Updated_Date { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<InventoryTransactions> InventoryTransactions { get; set; }
    }
}
