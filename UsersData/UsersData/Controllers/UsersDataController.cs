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
		List<Users> list = new List<Users>()
		{
			new Users
			{
				Id=10,
				Name="Vahe",
				Lastname="Sargsyan",
				Solary=100000,

			},
			new Users
			{
				Id=10,
				Name="Ani",
				Lastname="Karapetyan",
				Solary=150000,

			}
		};
		// GET: UsersData
		public ActionResult Index()
		{

			return View("GetUsers",(object)list);
		}

		// GET: UsersData/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		//GET: UsersData/Create
		public ActionResult Create()
		{
			return View("Index");
		}

		// POST: UsersData/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Users usersdata)
		{
			try
			{
				list.Add(usersdata);
				

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
			return View();
		}

		// POST: UsersData/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

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
			return View();
		}

		// POST: UsersData/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}