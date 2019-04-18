using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersData.Models;

namespace UsersData.Controllers
{
	public class UsersDataController : Controller
	{
        DBforUser dbforUser = new DBforUser();
        Users user = new Users();

		// GET: UsersData
		public ActionResult Index()
		{

			return View(dbforUser.Select(user));
		}

		// GET: UsersData/Details/5
		public ActionResult Details(int id)
		{
            List<Users> us = dbforUser.Select(user).Where(i => i.Id == id).ToList();
            return View(us[0]);
		}

		//GET: UsersData/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: UsersData/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Users usersdata)
		{
			try
			{

                dbforUser.Insert(usersdata);


                return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UsersData/Edit/5
		public ActionResult Edit(int id)
		{
            List<Users> us = dbforUser.Select(user).Where(i => i.Id == id).ToList();
            return View(us[0]);
		}

		// POST: UsersData/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, Users us)
		{
			try
			{
                dbforUser.Update( us,id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: UsersData/Delete/5
		public ActionResult Delete(int id)
		{
            List<Users> us = dbforUser.Select(user).Where(i => i.Id == id).ToList();
			return View(us[0]);
		}

		// POST: UsersData/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{

                //HttpRequest htRec =(HttpRequest) col;
                //id=Request["Id"]
                dbforUser.Delete(id);
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}