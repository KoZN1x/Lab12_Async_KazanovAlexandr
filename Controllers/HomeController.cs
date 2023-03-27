using Lav12_Async_KazanovAlexandr.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Lav12_Async_KazanovAlexandr.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Cancel async operation after input cancelDelay
        public async Task<IActionResult> Index(int? cancelDelay)
        {
            CancellationTokenSource token = new CancellationTokenSource();
            int y = 0;
            await Task.Run(() =>
            {
                if (cancelDelay != null)
                {
                    token.Cancel();
                }
            });
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(10);
                y++;
                if (token.IsCancellationRequested)
                {
                    await Task.Delay(cancelDelay.Value);
                    return StatusCode(299);
                }
            }
            return View(y);
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