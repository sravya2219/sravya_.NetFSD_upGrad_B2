using Microsoft.AspNetCore.Mvc;
using StudentDemo.DataAccess;
using StudentDemo.Models;

namespace StudentDemo.Controllers
{
    [Route("Calculate")]

    public class CalculatorController : Controller
    {
        private readonly ICalculatorService<Calculator> _calculatorService;
        public CalculatorController(ICalculatorService<Calculator> calculatorService)
        {
            this._calculatorService = calculatorService;
        }

        [Route("/cal")]
        [Route("Data", Name ="Data")]
        public IActionResult ViewAllData()
        {
            var data = _calculatorService.GetAllData();
            return View(data);
        }

        [HttpGet]
        [Route("Addition",Name ="Addition")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Saved", Name = "Saved")]
        public IActionResult Add(Calculator model)
        {
            var data = _calculatorService.Add(model);
            return RedirectToRoute("Data");
            return View(data);
        }
        [HttpGet]
        [Route("Subtract", Name ="Subtract")]
        public IActionResult Subtract()
        {
            return View();
        }

        [HttpPost]
        [Route("Sub", Name = "Sub")]
        public IActionResult Subtract(Calculator model)
        {
            var data = _calculatorService.Subtract(model);
            return RedirectToRoute("Data");
            return View(data);
        }

        [HttpGet]
        [Route("Mul",Name ="Mul")]
        public IActionResult Multiple()
        {
            return View();
        }

        [HttpPost]
        [Route("Multiple", Name = "Multiple")]
        public IActionResult Multiple(Calculator model)
        {
            var data = _calculatorService.Multiple(model);
            return RedirectToRoute("Data");
            return View(data);
        }

        [HttpGet]
        [Route("Div", Name ="Div")]
        public IActionResult Divide()
        {
            return View();
        }


        [HttpPost]
        [Route("Divide", Name = "Divide")] // ✅ FIX
        public IActionResult Divide(Calculator model)
        {
            var data = _calculatorService.Divide(model);
            return RedirectToRoute("Data");
            return View(data);
        }

    }
}
