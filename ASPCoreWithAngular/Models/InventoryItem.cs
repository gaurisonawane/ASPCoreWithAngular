using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Models
{
    public class InventoryItem
    {
        public int ItemId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
