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
		{
		ViewBag.EId = new SelectList(_db.Engineers, "EId", "EName");
		return View();
		}

	[HttpPost]
	public ActionResult Create(Machine machine, int EId)
	{
		_db.Machines.Add(machine);
		_db.SaveChanges();
		if (EId != 0)
		{
			_db
				.EngineerMachine
				.Add(new EngineerMachine()
				{
					EId = EId, MId = machine.MId});
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
		.FirstOrDefault(machine => machine.MId == id);
	return View(thisMachine);
	}
	public ActionResult Edit(int id)
	{
		var thisMachine = 
		_db.Machines.FirstOrDefault(machine => machine.MId == id);
		ViewBag.EId = new SelectList(_db.Engineers, "EId", "EName");
		return View(thisMachine);
	}
	[HttpPost]
	public ActionResult Edit(Machine machine, int EId)
	{
		if (EId != 0)
		{
			_db
				.EngineerMachine
				.Add(new EngineerMachine()
				{EId = EId, MId = machine.MId});
		}
		_db.Entry(machine).State = EntityState.Modified;
		_db.SaveChanges();
		return RedirectToAction("Index");
	}
	public ActionResult AddEngineer (Machine machine, int EId)
	{
		if (EId !=0)
		{
			_db
				.EngineerMachine
				.Add(new EngineerMachine()
				{ EId = EId, MId = machine.MId});
			_db.SaveChanges();
				}
				return RedirectToAction("Index");
		}
	public ActionResult Delete(int id)
	{
		var thisMachine =
		_db.Machines.FirstOrDefault(machine => machine.MId == id);
		return View(thisMachine);
	}
	[HttpPost, ActionName("Delete")]
	public ActionResult DeleteConfirmed(int id)
	{
		var thisMachine = 
		_db.Machines.FirstOrDefault(machine => machine.MId == id);
		_db.Machines.Remove(thisMachine);
		_db.SaveChanges();
		return RedirectToAction("Index");
	}
	[HttpPost]
	public ActionResult DeleteEngineer(int joinId)
	{
		var joinEntry =
		_db
			.EngineerMachine
			.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
		_db.EngineerMachine.Remove(joinEntry);
		_db.SaveChanges();
		return RedirectToAction("Index");
	}
	}

	}