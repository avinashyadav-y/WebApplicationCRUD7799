using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCRUD.Models;

namespace WebApplicationCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HRmanagementDbContext db;

        public DepartmentController(HRmanagementDbContext context )
        {
            this.db = context;
        }
        public async Task  <IActionResult> Index()
        {
            var Departments = await db.departments.ToListAsync();
            return View(Departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost ]
        public async Task  <IActionResult> Create (Department dept )
        {

            if(ModelState.IsValid)
            {
                await db.departments.AddAsync (dept);
                await db.SaveChangesAsync();
                TempData["Success"] = "Department Added Succesfuly";
                return RedirectToAction ("Index");
            }
            return View(dept);
        }
    }
}
