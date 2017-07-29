using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoPayments.Models;
using Incoding.CQRS;
using Microsoft.Extensions.DependencyInjection;

namespace DemoPayments.Controllers
{
    public class BaseController : Controller
    {
        public IDispatcher dispatcher;
        public BaseController(IDispatcher _dispatcher)
        {
            dispatcher = _dispatcher;
        }
    }
}
