using InventrySystemAPI.Data;
using InventrySystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace InventrySystemAPI.Controllers
{

    [ApiController]
    [Route("api/inventory/[controller]/")]
    public class ItemsController : Controller
    {
        public readonly InventryAPIdbCotext MyDbContext;
        public ItemsController(InventryAPIdbCotext dbContext)
        {
            MyDbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var singlecatogory = MyDbContext.Items.ToList();
            if (singlecatogory == null)
            {
                return NotFound();
            }

            return Ok(singlecatogory);
        }

        [HttpGet]
        [Route("{type}")]
        public async Task<IActionResult> GetContacts([FromRoute] string type)
        {
            var singlecatogory =  MyDbContext.Items.Where(item=>item.ItemsType == type);
            if (singlecatogory == null)
            {
                return NotFound();
            }

            return Ok(singlecatogory);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemsRequest addItem)
        {
            var item = new Items()
            {
                Id = Guid.NewGuid(),
                ItemsName = addItem.ItemsName,
                ItemsQuantity = addItem.ItemsQuantity,
                ItemsType = addItem.ItemsType,
                Price = addItem.Price
            };
            await MyDbContext.Items.AddAsync(item);
            await MyDbContext.SaveChangesAsync();
            return Ok(item);
        }
     
        
        [HttpPatch]
        public async Task<IActionResult> UpdateQuantity([FromBody] List<UpdateQuantityRequest> updateQuantityRequest)
        {
            //List<UpdateQuantityRequest> quantitiesList = JsonConvert.DeserializeObject<List<UpdateQuantityRequest>>(updateQuantityRequest);

            foreach (var item in updateQuantityRequest)
            {
                var singlecatogory = MyDbContext.Items.Where(i => i.ItemsName == item.ItemsName).Single();
                if (singlecatogory != null)
                {
                    singlecatogory.ItemsQuantity = singlecatogory.ItemsQuantity - item.ItemsQuantity;

                }


            }

            await MyDbContext.SaveChangesAsync();
            return Ok(updateQuantityRequest);
        }


        [HttpGet]
        [Route("Bills")]
        public async Task<IActionResult> GetBills()
        {
            var singlecatogory = MyDbContext.Bills.ToList();
            if (singlecatogory == null)
            {
                return NotFound();
            }

            return Ok(singlecatogory);
        }


        [HttpPost]
        [Route("add_bill")]
        public async Task<IActionResult> AddBills([FromBody] AddBills addBills)
        {
            var singlebill = new Bills()
            {
                Id = Guid.NewGuid(),
                CustomerName = addBills.CustomerName,
                totalamount = addBills.totalamount
            };
            await MyDbContext.Bills.AddAsync(singlebill);
            await MyDbContext.SaveChangesAsync();
            return Ok(singlebill);
        }
    }
}
