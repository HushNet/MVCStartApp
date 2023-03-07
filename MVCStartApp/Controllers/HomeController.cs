using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVCStartApp.Models;
using MVCStartApp.Models.Db;

namespace MVCStartApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository repo;
        private readonly ILogger<HomeController> logger;
        private readonly IRequestRepository requestRepository;

        public HomeController(ILogger<HomeController> logger, IBlogRepository repo, IRequestRepository requestRepository)
        {
            this.logger = logger;
            this.repo = repo;
            this.requestRepository = requestRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> logs()
        {
            var requests = await requestRepository.GetRequests();
            return View(requests);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}