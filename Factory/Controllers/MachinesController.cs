using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Factory.Models;

namespace Factory.Controllers
{
	public class MachinesController : Controller
	{
		private readonly FactoryContext _db;

		public MachinesController(FactoryContext db)
		{
			_db = db;
		}
		public ActionResult Index()
		{
			return View(_db.Machines.ToList());
		}
		public ActionResult Create()
		ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
		return View();
	}
	[HttpPost]
	public ActionResult Create(Machine machine, int MachineId)
	{
		_db.Machines.Add(machine);
		_db.SaveChanges();
		if (EngineerId != 0)
		{
			_db
				.EngineerMachine
				.Add(new EngineerMachine()
				{
					EngineerId = EngineerId, MachineId = machine.MachineId});
					_db.SaveChanges();
		}
		return RedirectToAction("Index");
	}
	public ActionResult Details (int id)
	{
		var thisMachine =
		_db 
		.Machines 
		.Include (machine=> machine.JoinEntities)
		.ThenInclude(join => join.Engineer)
		.FirstOrDefault => ()machine.MachineId == id;
	
	return View(thisMachine)
	}

				}
		}
	}

}
}