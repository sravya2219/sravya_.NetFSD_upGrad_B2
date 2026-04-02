using Microsoft.AspNetCore.Mvc;
using StudentDemo.Models;

namespace StudentDemo.Controllers
{
    [Route("Feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("form")]
        public IActionResult Submit()
        {
            return View();
        }

        [HttpPost("Submit")]
        public IActionResult Submit(Feedback feedback)
        {
            if(feedback.Rating >= 4)
            {
                ViewData["Message"] = "Thank you for your valuable feedback";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback!";
            }

            return View("Result");
        }
    }
}
