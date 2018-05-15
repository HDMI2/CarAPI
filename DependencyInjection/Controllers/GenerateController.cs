using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class GenerateController : Controller
    {
        private readonly IScoped _scoped;
        private readonly ITransient _transient;
        private readonly ISingelton _singelton;

        public GenerateController(IScoped scoped, ITransient transient, ISingelton singelton)
        {
            _scoped = scoped;
            _transient = transient;
            _singelton = singelton;

        }

        public IActionResult Index()
        {
            ViewBag.Transient = _transient;
            ViewBag.Scoped = _scoped;
            ViewBag.Singelton = _singelton;
            return View();
        }
    }
}