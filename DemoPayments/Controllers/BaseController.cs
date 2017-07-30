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
        protected readonly IDispatcher Dispatcher;
        public BaseController(IDispatcher _dispatcher)
        {
            Dispatcher = _dispatcher;
        }
    }
}
