using GunsOfTheOldWest.UI.Mvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace GunsOfTheOldWest.UI.Mvc.Controllers
{
	public class GameController : Controller
	{
		private static GameState _gameState = new GameState { BulletsLeft = 12 };

		public IActionResult Index()
		{
			return View(_gameState);
		}

		// SHOOT
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Shoot()
		{
			if (_gameState.BulletsLeft <= 0)
			{
				return RedirectToAction("Reload");  // Stuurt gebruiker naar de Reload action method
			}

			_gameState.BulletsLeft--;
			Random random = new Random();
			int shot = random.Next(0, 11);
			_gameState.NumberShot = shot; //schotnummer opslaan

            if (shot <= 3)
			{
				_gameState.IsWinner = true;
				return RedirectToAction("Winner");
			}
            return RedirectToAction("Index");
		}

		// WINNER
		public IActionResult Winner()
		{
			return View();
		}

		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SubmitWinner(Player player)
		{
			if (ModelState.IsValid)
			{
				player.SubmissionDate = DateTime.Now;
				return RedirectToAction("Summary", player);
			}
			return View("Winner");
		}

		// SUMMARY
		public IActionResult Summary(Player player)
		{
			return View(player);
		}

		// RELOAD
		public IActionResult Reload()
		{
			return View();
		}

		// BUY BULLETS
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BuyBullets(int amount)
		{
			_gameState.BulletsLeft += amount;
			return RedirectToAction("Index");
		}
	}
}
