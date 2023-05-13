using CPSite.Models;

using DAL;
using DAL.Models;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace CPSite.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        public DatabaseManager db { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            db = new DatabaseManager();
        }

        public IActionResult Index()
        {
            List<TravelCommand> commands = db.GetTravelCommands();
            return View(commands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TravelCommand travelCommand)
        {
            db.CreateTravelCommand( travelCommand.Participant, travelCommand.StartLocation, travelCommand.EndLocation,
                travelCommand.StartTime, travelCommand.EndTime, travelCommand.Transportation, travelCommand.Status);
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Edit(int id)
        {
            return View(db.GetTravelCommandById(id));
        }

        [HttpPost]
        public IActionResult Edit(TravelCommand travelCommand)
        {
            if (ModelState.IsValid)
            {
                db.UpdateTravelCommand(travelCommand);
                return RedirectToAction("Index");
            }

            return View(travelCommand);
        }
        public IActionResult Delete(int id)
        {
            int retval = db.DeleteTravelCommand(id);
            if (retval > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}