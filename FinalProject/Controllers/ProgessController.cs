using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ProgressController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProgressController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // POST: Progress/UpdateCompletedLessons
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateCompletedLessons(int lessonsCompleted)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.CompletedLessons = lessonsCompleted;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home"); // Redirect to a suitable page
            }
            return NotFound();
        }

        // POST: Progress/UpdateQuizScores
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateQuizScores(int quizScores)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.QuizScores = quizScores;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home"); // Redirect to a suitable page
            }
            return NotFound();
        }

        // POST: Progress/UpdateLearningMilestones
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> UpdateLearningMilestones(string milestones)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                user.LearningMilestones = milestones;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Home"); // Redirect to a suitable page
            }
            return NotFound();
        }
    }
}
