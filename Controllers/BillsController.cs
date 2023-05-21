using InventrySystemAPI.Data;
using InventrySystemAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace InventrySystemAPI.Controllers
{
    [ApiController]
    [Route("api/inventory/[controller]")]

    public class BillsController : Controller
    {
        public readonly InventryAPIdbCotext? MyDbContext;

        public BillsController(InventryAPIdbCotext? myDbContext)
        {
            MyDbContext = myDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetBills()
        {
            var singlecatogory = MyDbContext!.Bills.ToList();
            if (singlecatogory == null)
            {
                return NotFound();
            }

            return Ok(singlecatogory);
        }
        [HttpGet]
        [Route("{personName}")]
        public async Task<IActionResult> getBillbyName([FromRoute] string personName)
        {
            var singlecatogory = MyDbContext!.Bills.Where(bill => bill.CustomerName == personName);
            if (singlecatogory == null)
            {
                return NotFound();
            }

            return Ok(singlecatogory);
        }


        [HttpPost]
        public async Task<IActionResult> AddBills([FromBody] AddBills addBills)
        {
            var singlebill = new Bills()
            {
                Id = Guid.NewGuid(),
                CustomerName = addBills.CustomerName,
                totalamount = addBills.totalamount
            };
            await MyDbContext!.Bills.AddAsync(singlebill);
            await MyDbContext.SaveChangesAsync();
            return Ok(singlebill);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> deleteSingleBill([FromRoute] Guid id)
        {
            var singlecontact = await MyDbContext!.Bills.FindAsync(id);
            if (singlecontact == null)
            {
                return NotFound();
            }
            MyDbContext.Remove(singlecontact);
            await MyDbContext.SaveChangesAsync();
            var response = new
            {

                status = "200",
                message = "Bill deleted successfully",
                data = singlecontact
            };
            return Ok(response);

        }

    }
}
