using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;

namespace Factory.Controllers
{
	public class EngineersController : Controller 
	{
		private readonly FactoryContext _db;

		public EngineersController(FactoryContext db)
		{
			_db = db;
		}
		public ActionResult Index()
		{
			List<Engineer>model = _db.Engineers.ToList();
			return View(model);
		}
		public ActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Create(Engineer engineer)
		{
			_db.Engineers.Add(engineer);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult Details(int id)
		{
			var thisEngineer = _db.Engineers.Include(engineer=> engineer.JoinEntities).ThenInclude(join => join.Machine).FirstOrDefault(engineer=> engineer.EId == id);
			return View(thisEngineer);
		}
		public ActionResult Edit(int id)
		{
			var thisEngineer = _db.Engineers.FirstOrDefault(engineer=> engineer.EId == id);
			ViewBag.MId = new SelectList(_db.Machines, "MId", "MName");
			return View(thisEngineer);
		}
	[HttpPost]
	public ActionResult Edit(Engineer engineer, int MId)
	{
		if (MId != 0 && _db.EngineerMachine.FirstOrDefault(_d => _d.MId == MId && _d.EId == engineer.EId) == null)
		{
			_db
				.EngineerMachine
				.Add(new EngineerMachine
				{
					MId = MId, EId = engineer.EId}); 
				_db.SaveChanges();
			}

		_db.Entry(engineer).State = EntityState.Modified;
		_db.SaveChanges();
		return RedirectToAction("Index");

		}
		public ActionResult AddMachine(int id)
		{
			var thisEngineer =
			_db.Engineers.FirstOrDefault(engineer => engineer.EId == id );
			ViewBag.MId = new SelectList(_db.Machines, "MId", "MName");
			return View(thisEngineer);
		}

		[HttpPost]
		public ActionResult AddMachine(Engineer engineer, int MId)
		{
			if (MId !=0)
			{
				_db
					.EngineerMachine
					.Add(new EngineerMachine()
					{MId = MId, EId = engineer.EId});
				_db.SaveChanges();
			}
			return RedirectToAction("Index");
			}

			public ActionResult Delete (int id)
			{
				var thisEngineer = 
				_db.Engineers.FirstOrDefault(engineer => engineer.EId == id);
				return View(thisEngineer);
			}
			[HttpPost, ActionName("Delete")]
			public ActionResult DeleteConfirmed(int id)
			{
				var thisEngineer = 
				_db.Engineers.FirstOrDefault(engineer=> engineer.EId == id);
				_db.Engineers.Remove(thisEngineer);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
	}
}