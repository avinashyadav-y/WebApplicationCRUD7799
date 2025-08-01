using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Controllers
{
    public class EmployeController : Controller
    {
        public readonly HRmanagementDbContext db;

        public EmployeController(HRmanagementDbContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Employees = await db.employees.Include(e => e.Department).ToListAsync();
            return View(Employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await db.departments.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee obj)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Departments = await db.departments.ToListAsync();
                return View(obj); 
            }

            db.employees.Add(obj);
            await db.SaveChangesAsync();
            TempData["Success"] = "Employee Added Successfully";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var Employee = await db.employees
                                   .Include(e => e.Department)
                                   .FirstOrDefaultAsync(e => e.EmpID == id);

            if (Employee == null)
                return NotFound();

            return View(Employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var Employee = await db.employees
                                   .Include(e => e.Department)
                                   .FirstOrDefaultAsync(e => e.EmpID == id);

            if (Employee == null)
                return NotFound();

            return View(Employee);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var Employee = await db.employees.FindAsync(id);
            if (Employee == null)
                return NotFound();

            db.employees.Remove(Employee);
            await db.SaveChangesAsync();
            TempData["Success"] = "Employee Deleted Successfully";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = await db.departments.ToListAsync();
               
            if (id == null)
            {
                return NotFound();

            }

            var Employee = await db.employees
                                   .Include(e => e.Department)
                                   .FirstOrDefaultAsync(e => e.EmpID == id);

            if (Employee == null)
            {
                return NotFound();

            }


            return View(Employee);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee obj)
        {
            if (ModelState.IsValid)
            {
                db.employees.Update(obj);
                await db.SaveChangesAsync();
                TempData["Success"] = "Employee Updated Successfully";
                return RedirectToAction("Index");

            }
            ViewBag.Departments = await db.departments.ToListAsync();
            return View(obj);

        
            
            
        }

    }
}
