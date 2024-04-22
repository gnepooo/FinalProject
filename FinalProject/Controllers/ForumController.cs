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
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ForumController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Forum
        public async Task<IActionResult> Index()
        {
            var threads = await _context.ForumThreads
                .Include(t => t.User)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
            return View(threads);
        }

        // GET: Forum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thread = await _context.ForumThreads
                .Include(t => t.User)
                .Include(t => t.Replies)
                .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (thread == null)
            {
                return NotFound();
            }

            return View(thread);
        }

        // GET: Forum/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forum/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateForumThreadViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var thread = new ForumThread
                {
                    Title = model.Title,
                    Content = model.Content,
                    UserId = user.Id,
                    CreatedAt = DateTime.Now
                };
                _context.ForumThreads.Add(thread);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Forum/Reply/5
        [Authorize]
        public async Task<IActionResult> Reply(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thread = await _context.ForumThreads.FindAsync(id);
            if (thread == null)
            {
                return NotFound();
            }

            var model = new ReplyViewModel { ThreadId = thread.Id };
            return View(model);
        }

        // POST: Forum/Reply/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Reply(ReplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                var reply = new ForumReply
                {
                    Content = model.Content,
                    UserId = user.Id,
                    ThreadId = model.ThreadId,
                    CreatedAt = DateTime.Now
                };
                _context.ForumReplies.Add(reply);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = model.ThreadId });
            }
            return View(model);
        }

        // GET: Forum/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thread = await _context.ForumThreads
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.Id == id);
            if (thread == null)
            {
                return NotFound();
            }

            return View(thread);
        }

        // POST: Forum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thread = await _context.ForumThreads.FindAsync(id);
            _context.ForumThreads.Remove(thread);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
