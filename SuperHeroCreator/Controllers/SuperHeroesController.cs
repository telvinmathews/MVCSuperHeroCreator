using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroCreator.Data;
using SuperHeroCreator.Models;

namespace SuperHeroCreator.Controllers
{
    public class SuperHeroesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuperHeroesController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperHeroes
        public ActionResult Index()
        {
           var superHeroes = _context.Heroes;
            return View(superHeroes);
        }

        // GET: SuperHeroes/Details/5
        public ActionResult Details(int id)
        {
            var superHeroToCheck = _context.Heroes.Where(s => s.Id == id).FirstOrDefault();

            return View(superHeroToCheck);
        }

        // GET: SuperHeroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHeroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero newHero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Heroes.Add(newHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SuperHeroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero hero)
        {
            try
            {
                // TODO: Add update logic here
               var heroToBeEdited = _context.Heroes.Where(h => h.Id == id).FirstOrDefault();
                heroToBeEdited.Name = hero.Name;
                heroToBeEdited.AlterEgo = hero.AlterEgo;
                heroToBeEdited.PrimaryAbility = hero.PrimaryAbility;
                heroToBeEdited.SecondaryAbility = hero.SecondaryAbility;
                heroToBeEdited.CatchPhrase = hero.CatchPhrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHeroes/Delete/5
        public ActionResult Delete(int id)
        {
           // _context.Heroes.Remove(id);
            _context.SaveChanges();
            return View();
        }

        // POST: SuperHeroes/Delete/5
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