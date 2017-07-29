using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoPayments.Models;
using Incoding.Block.IoC;
using Incoding.CQRS;
using Operations.Query;
using Operations;

namespace DemoPayments.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IDispatcher _dispatcher) : base(_dispatcher)
        {
        }
        public IActionResult Index()
        {
            return View(dispatcher.Query(new GetUsersQuery()));
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

        [HttpPost]
        public IActionResult CreateUserCommand(CreateUserCommand command)
        {
            dispatcher.Push(command);
            return RedirectToAction("Index");
        }

     
    }
}
