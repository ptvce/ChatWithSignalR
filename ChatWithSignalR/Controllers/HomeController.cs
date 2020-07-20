using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChatWithSignalR.Models;
using ChatWithSignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ChatWithSignalR.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(IHubContext<ChatHub> hubContext, ILogger<HomeController> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SendMessage(string message)
        {
            //send message with signalRHub
            await _hubContext.Clients.All.SendAsync("adminMessage", message);

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
