using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Leaf.Web2.Models;
using Leaf.Services.Demo;
using Leaf.Services.Users;
using Leaf.Core.Infrastructure;

namespace Leaf.Web2.Controllers
{
    public class HomeController : Controller
    {
        private ITest _iTest;
        private IUserServices _iUsers;
        public HomeController(ITest iTest, IUserServices iUsers)
        {
            this._iTest = iTest;
            this._iUsers = iUsers;
        }
        public IActionResult Index()
        {
            var str = _iTest.GetStrTest();

            var test = EngineContext.Current.Resolve<ITest>().GetStrTest();

            var data = _iUsers.GetAll(o => o.Id > 0);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
