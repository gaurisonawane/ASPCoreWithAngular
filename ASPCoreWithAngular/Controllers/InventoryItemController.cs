using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCoreWithAngular.Interfaces;
using ASPCoreWithAngular.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreWithAngular.Controllers
{
    [Route("api/[controller]")]
    public class InventoryItemController : Controller
    {
        private readonly IInventory objitem;

        public InventoryItemController(IInventory _objitem)
        {
            objitem = _objitem;
        }

        [HttpGet]
        [Route("Index")]
        public IEnumerable<InventoryItem> Index()
        {
            return objitem.GetAllItems();
        }

        [HttpPost]
        [Route("Create")]
        public int Create([FromBody] InventoryItem item)
        {
            return objitem.AddItem(item);
        }

        [HttpGet]
        [Route("Details/{id}")]
        public InventoryItem Details(int id)
        {
            return objitem.GetItemData(id);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public int Delete(int id)
        {
            return objitem.DeleteItem(id);
        }

    }
}
