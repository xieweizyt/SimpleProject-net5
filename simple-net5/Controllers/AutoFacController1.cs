using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IOC.IBLL;

namespace simple_net5.Controllers
{
    public class AutoFacController1 : Controller
    {
        public IHeadphone _headphone = null;
        public AutoFacController1(IHeadphone headphone)
        {
            _headphone = headphone;
        }
        public IActionResult Index()
        {
            _headphone.Show();
            return View();
        }
    }
}
