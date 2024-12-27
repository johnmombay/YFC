using Admin.YFC.Models;
using Admin.YFC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin.YFC.Controllers
{
	public class StatementsController : Controller
	{
		private readonly StatementServices _statementServices;

		public StatementsController(StatementServices statementServices)
		{
			_statementServices = statementServices;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> GetStatements()
		{
			var statements = await _statementServices.GetStatements();
			return Json(new { data = statements });
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Message,Author")] Statement statement)
		{
			if (ModelState.IsValid)
			{
				await _statementServices.AddStatement(statement);
				return RedirectToAction("Index");
			}
			return View(statement);
		}

		public async Task<IActionResult> Edit(int id)
		{
			ViewBag.StatementId = id;
			var statement = await _statementServices.GetStatementById(id);
			return View(statement);
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, [Bind("StatementId,Message,Author")] Statement statement)
		{
			if (ModelState.IsValid)
			{
				await _statementServices.UpdateStatement(statement);
				return RedirectToAction("Index");
			}
			return View(statement);
		}

		public async Task<IActionResult> Remove(int id)
		{
			ViewBag.StatementId = id;
			var statement = await _statementServices.GetStatementById(id);
			return View(statement);
		}

		public async Task<IActionResult> Delete(int id)
		{
			await _statementServices.DeleteStatement(id);
			return RedirectToAction("Index");
		}
	}
}
