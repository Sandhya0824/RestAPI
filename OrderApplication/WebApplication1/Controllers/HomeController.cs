using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using OrderApplication;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        string BaseURL = "http://localhost:55950/";
        public async Task<IActionResult> GetAllOrders()
        {
            List<OrderApplication.Order> orders = new List<OrderApplication.Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Orders");
                if (res.IsSuccessStatusCode)
                {
                    var Result = res.Content.ReadAsStringAsync().Result;
                    orders = JsonConvert.DeserializeObject<List<Order>>(Result);
                }
            }
            return View(orders);
        }

        public async Task<IActionResult> GetOrder(int id)
        {
            Order order1 = new Order();
            List<OrderApplication.Order> orders = new List<OrderApplication.Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Orders/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var Result = res.Content.ReadAsStringAsync().Result;
                    order1 = JsonConvert.DeserializeObject<Order>(Result);
                }
            }
            return View(order1);
        }

        public IActionResult AddOrder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddOrder(Order order1)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.PostAsJsonAsync(BaseURL + "api/Orders", order1).Result;
                if (res.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Added the order successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Oops... Something went wrong";
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            Order order1 = new Order();
            List<OrderApplication.Order> orders = new List<OrderApplication.Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Orders/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var Result = res.Content.ReadAsStringAsync().Result;
                    order1 = JsonConvert.DeserializeObject<Order>(Result);
                }
            }
            return View(order1);
        }

        [HttpPost]
        public IActionResult UpdateOrder(Order order1)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.PutAsJsonAsync(BaseURL + "api/Orders/"+order1.id,order1).Result;
                if (res.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Updated the order successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Oops... Something went wrong";
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            Order order1 = new Order();
            List<OrderApplication.Order> orders = new List<OrderApplication.Order>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = await client.GetAsync("api/Orders/" + id);
                if (res.IsSuccessStatusCode)
                {
                    var Result = res.Content.ReadAsStringAsync().Result;
                    order1 = JsonConvert.DeserializeObject<Order>(Result);
                }
            }
            return View(order1);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage res = client.DeleteAsync(BaseURL + "api/Orders"+id).Result;
                if (res.IsSuccessStatusCode)
                {
                    ViewBag.msg = "Deleted the order successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Oops... Something went wrong";
                }
                return View();
            }
        }
    }
}
