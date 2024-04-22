// AssignmentController.cs
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AssignmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Assignment
        public async Task<IActionResult> Index()
        {
            var assignments = await _context.Assignments.ToListAsync();
            return View(assignments);
        }

        // GET: Assignment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FirstOrDefaultAsync(m => m.Id == id);
            if (assignment == null)
            {
                return NotFound();
            }

            return View(assignment);
        }

        // Other actions (Create, Edit, Delete) can be implemented similarly...
    }
}
