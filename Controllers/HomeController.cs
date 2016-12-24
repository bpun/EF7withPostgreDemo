using System.Linq;
using EF7withPostgreDemo.DbContexts;
using EF7withPostgreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EF7withPostgreDemo.Controllers
{
    public class HomeController : Controller
    {
          private readonly PostgreContext _context;
        public HomeController(
           PostgreContext context
        )
        {
            _context= context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = _context.Persons.ToList();

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            if(ModelState.IsValid){
                _context.Persons.Add(person);
                _context.SaveChanges();

              return  RedirectToAction("Index");
            }
            
            return View(person);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id <=0)
            {
                return NotFound();
            }
            else{
                var data =  _context.Persons.FirstOrDefault(x => x.ID == id);
                return View(data);
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("ID,Name,Address,Phone")] Person person)
        {
            if (id <=0)
            {
                return NotFound();
            }
             if (ModelState.IsValid)
            {
                 _context.Persons.Update(person);
                 _context.SaveChanges();

                return  RedirectToAction("Index");
            }
            return View(person);
        }
        public IActionResult Delete(int id)
        {
            var person = _context.Persons.FirstOrDefault(m => m.ID == id);
            if (person == null)
            {
                return RedirectToAction("Index");
            }
            _context.Persons.Remove(person);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
