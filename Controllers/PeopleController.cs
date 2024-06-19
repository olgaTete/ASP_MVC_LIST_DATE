using Microsoft.AspNetCore.Mvc;
using ListDate2.Models.Entities;
using ListDate2.Models;
using ListDate2.Models.View;
using ListDate2.Models.Repo;
using System;

namespace ListDate2.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        // GET: People
        public IActionResult Index(string searchString)
        {
            var viewModel = new PeopleViewModel
            {
                SearchString = searchString
            };

            if (string.IsNullOrWhiteSpace(searchString))
            {
                viewModel.People = _peopleService.All();
            }
            else
            {
                viewModel.People = _peopleService.Search(searchString);

                viewModel.SearchResult = viewModel.People.Any()
                    ? $"Results found for '{searchString}'."
                    : $"No results found for '{searchString}'.";
            }

            return View(viewModel);
        }

        // GET: People/Details/5
        public IActionResult Details(int id)
        {
            var person = _peopleService.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Delete/5
        public IActionResult Delete(int id)
        {
            var person = _peopleService.FindById(id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _peopleService.Remove(id);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}


