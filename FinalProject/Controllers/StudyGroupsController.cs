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
    public class StudyGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StudyGroupsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: StudyGroups
        public async Task<IActionResult> Index()
        {
            var groups = await _context.StudyGroups.ToListAsync();
            return View(groups);
        }

        // GET: StudyGroups/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudyGroups/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(StudyGroup studyGroup)
        {
            if (ModelState.IsValid)
            {
                _context.StudyGroups.Add(studyGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studyGroup);
        }

        // GET: StudyGroups/Join/5
        [Authorize]
        public async Task<IActionResult> Join(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.StudyGroups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: StudyGroups/Join/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Join(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var group = await _context.StudyGroups.FindAsync(id);
            if (user != null && group != null)
            {
                var membership = new StudyGroupMembership
                {
                    UserId = user.Id,
                    StudyGroupId = id
                };
                _context.StudyGroupMemberships.Add(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }

        // GET: StudyGroups/Leave/5
        [Authorize]
        public async Task<IActionResult> Leave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            var membership = await _context.StudyGroupMemberships.FirstOrDefaultAsync(m => m.StudyGroupId == id && m.UserId == user.Id);
            if (membership != null)
            {
                _context.StudyGroupMemberships.Remove(membership);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
    }
}
