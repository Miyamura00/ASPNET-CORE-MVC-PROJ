using Microsoft.AspNetCore.Mvc;
using PracticeProjMVC.Data;
using PracticeProjMVC.Models;


namespace PracticeProjMVC.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly AppDBContext _db;

        public EmployeeController(AppDBContext db)
        {
            _db = db;
        }

        //GET EmployeeList
        public IActionResult Index()
        {
            IEnumerable<EmployeeModel> objEmployeeList = _db.EmployeeModels;
            return View(objEmployeeList);
        }

        //GET
        public IActionResult AddEmp()
        {

            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmp(EmployeeModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeModels.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee Added Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult EditEmp(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.EmployeeModels.Find(id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditEmp(EmployeeModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.EmployeeModels.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Employee Updated Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult DelEmp(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var EmployeeFromDb = _db.EmployeeModels.Find(id);

            if (EmployeeFromDb == null)
            {
                return NotFound();
            }
            return View(EmployeeFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Del(int? id)
        {
            var obj = _db.EmployeeModels.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.EmployeeModels.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Employee Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}