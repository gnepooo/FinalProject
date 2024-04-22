using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class GroupProjectsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public GroupProjectsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: GroupProjects
        public async Task<IActionResult> Index()
        {
            var projects = await _context.GroupProjects.ToListAsync();
            return View(projects);
        }

        // GET: GroupProjects/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: GroupProjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(GroupProject groupProject)
        {
            if (ModelState.IsValid)
            {
                _context.GroupProjects.Add(groupProject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groupProject);
        }

        // GET: GroupProjects/Join/5
        [Authorize]
        public async Task<IActionResult> Join(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.GroupProjects.FindAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: GroupProjects/Join/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Join(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var project = await _context.GroupProjects.FindAsync(id);
            if (user != null && project != null)
            {
                var membership = new GroupMembership
                {
                    UserId = user.Id,
                    GroupProjectId = id
                };
                _context.GroupMemberships.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        // GET: GroupProjects/Leave/5
        [Authorize]
        public async Task<IActionResult> Leave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var membership = await _context.GroupMemberships.FirstOrDefaultAsync(m => m.GroupProjectId == id && m.UserId == user.Id);
            if (membership != null)
            {
                _context.GroupMemberships.Remove(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
