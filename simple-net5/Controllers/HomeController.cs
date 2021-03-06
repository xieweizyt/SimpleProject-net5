using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using simple_net5.Models;
using simple_net5.ReadAppsetting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IOC.CustomerIOC;
using IOC.IBLL;

namespace simple_net5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        [SelPropAttr]
        public IPhone Phone { get; set; }

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            //_logger.LogInformation("123");
        }

        public IPhone phone1;
        [SelMethodAttr]
        public void SetValue(IPhone phone)
        {
            phone1 = phone;
        }

        public IActionResult Index()
        {
            ReadAppSettingSimple.ReadByBuild(_configuration);
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
