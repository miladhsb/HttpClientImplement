using HttpClientImplement.Models;
using HttpClientImplement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HttpClientImplement.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpCientService _httpCient;

        public HomeController(ILogger<HomeController> logger , IHttpCientService httpCient)
        {
            _logger = logger;
            this._httpCient = httpCient;
        }

        public async Task<IActionResult> Index()
        {
          var res=await  _httpCient.GetStringAsync("api/person");

            if (res.IsSucsess)
            {
                foreach (var item in res.responseMessage.RequestMessage.Headers)
                {
                    Console.WriteLine(item.Value.First());
                }
               
                Console.WriteLine(res.Content);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}