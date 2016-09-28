using Microsoft.AspNetCore.Mvc;
using Chronopanel.Site.Models.TemplatesCustomization;

namespace Chronopanel.Site.Controllers
{
    [Route("templates/customization")]
    public class TemplatesCustomizationController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromQuery]IndexRequest request)
        {
            if (request.ContainsValidColors())
            {
                var customizations = System.IO.File.ReadAllText("templates/customizations.css");

                customizations = customizations
                    .Replace("$background-color", $"#{request.BackgroundColor}")
                    .Replace("$hours-active-color", $"#{request.HoursActiveColor}")
                    .Replace("$hours-inactive-color", $"#{request.HoursInactiveColor}")
                    .Replace("$minutes-active-color", $"#{request.MinutesActiveColor}")
                    .Replace("$minutes-inactive-color", $"#{request.MinutesInactiveColor}")
                    .Replace("$seconds-active-color", $"#{request.SecondsActiveColor}")
                    .Replace("$seconds-inactive-color", $"#{request.SecondsInactiveColor}");

                return Content(customizations, "text/css");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
