using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController>_logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Login(bool showerror)
		{
			if (HttpContext.Session.GetString("LogSession") != null)
			{
				return RedirectToAction("Index");
			}
			return View(new LoginUtente(showerror));
		}

		[HttpPost]
		public IActionResult Login(Utente u)
		{
			var log = Database.Login(u.UserName);
			if (log != "Dati non validi")
			{
				HttpContext.Session.SetString("LogSession", log);
			}
			else
			{
				HttpContext.Session.Remove("LogSession");
				return RedirectToAction("Login", new { showerror = true });
			}

			return RedirectToAction("Index");
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}