using ASPCoreWithAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreWithAngular.Interfaces
{
    public interface IInventory
    {
        IEnumerable<InventoryItem> GetAllItems();
        int AddItem(InventoryItem item);
        InventoryItem GetItemData(int id);
        int DeleteItem(int id);
    }
}
