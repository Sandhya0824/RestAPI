using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingStuffAPI.Models;
using OrderingStuffAPI.Data;

namespace OrderingStuffAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderingStuffController : ControllerBase
    {
        private readonly ApiContext _context;

        public OrderingStuffController(ApiContext context)
        {
            _context = context;
        }

        //POST
        [HttpPost]
        public JsonResult CreateEdit(OrderingStuff order)
        {
            if (order.Id == 0)
            {
                _context.Orders.Add(order);
            }
            else
            {
                var orderInDb = _context.Orders.Find(order.Id);
                if (orderInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else
                {
                    orderInDb = order;
                }
            }

            _context.SaveChanges();
            return new JsonResult(Ok(order));

        }

        //GET
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Orders.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            else
            {
                return new JsonResult(Ok(result));
            }
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id) 
        {
            var result = _context.Orders.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            else
            {
                _context.Orders.Remove(result);
            }
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }

        //Get All orders
        [HttpGet()]
        public JsonResult GetAll() 
        { 
            var result = _context.Orders.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
