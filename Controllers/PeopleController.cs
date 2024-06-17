
using Microsoft.AspNetCore.Mvc;
using ListDate2.Models.Entities;
using ListDate2.Models;
using ListDate2.Models.View;
using ListDate2.Models.Repo;

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

            if (searchString == null || searchString.Trim() == "")
            {
                viewModel.People = _peopleService.All();

            }
            else
            {
                viewModel.People = _peopleService.Search(searchString);

                if (viewModel.People.Any())
                {
                    viewModel.SearchResult = $"Results found for '{searchString}'.";
                }
                else
                {
                    viewModel.SearchResult = $"No results found for '{searchString}'.";
                }
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

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Phone,City")] CreatePersonViewModel person)
        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        //// GET: People/Edit/5
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var person = _peopleService.FindAsync(id);
        //    if (person == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(person);
        //}

        //// POST: People/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,City")] Person person)
        //{
        //    if (id != person.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(person);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PersonExists(person.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(person);
        //}

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
        [ValidateAntiForgeryToken]
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
    //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    //public IActionResult Error()
    //{
    //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    //}
}



