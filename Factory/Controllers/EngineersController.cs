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
	}
}