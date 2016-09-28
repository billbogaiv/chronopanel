using System;
using Microsoft.AspNetCore.Mvc;
using Chronopanel.Site.Models.Customize;
using Chronopanel.Site.ViewModels.Customize;
using Home = Chronopanel.Site.Models.Home;
using System.Collections.Generic;
using Chronopanel.Site.Models;

namespace Chronopanel.Site.Controllers
{
    [Route("panels/bcd/customize")]
    public class CustomizeController : Controller
    {
        public CustomizeController(IEnumerable<ColorSwatch> colorSwatches)
        {
            this.colorSwatches = colorSwatches;
        }

        private readonly IEnumerable<ColorSwatch> colorSwatches;

        [HttpGet]
        public IActionResult Index([FromQuery]IndexRequest request)
        {
            if (!request.ContainsValidColors())
            {
                throw new Exception("Invalid colors.");
            }

            var response = new IndexResponse(
                request.BackgroundColor,
                request.HoursActiveColor,
                request.HoursInactiveColor,
                request.MinutesActiveColor,
                request.MinutesInactiveColor,
                request.SecondsActiveColor,
                request.SecondsInactiveColor,
                colorSwatches);

            return View(response);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest request)
        {
            var response = Home.IndexRequest.CreateRequest(
                    request.BackgroundColor,
                    request.HoursActiveColor,
                    request.HoursInactiveColor,
                    request.MinutesActiveColor,
                    request.MinutesInactiveColor,
                    request.SecondsActiveColor,
                    request.SecondsInactiveColor);

            if (!response.ContainsValidColors())
            {
                throw new Exception("Invalid colors.");
            }
            else
            {
                return RedirectToAction("Index", "Home", response);
            }
        }
    }
}
