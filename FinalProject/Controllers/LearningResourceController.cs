// LearningResourceController.cs
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using System.Linq;

namespace FinalProject.Controllers
{
    public class LearningResourceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LearningResourceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string searchString, string subject, int? gradeLevel, string resourceType)
        {
            var resources = _context.LearningResources.AsQueryable();

            // Apply search filter
            if (!string.IsNullOrEmpty(searchString))
            {
                resources = resources.Where(r => r.Title.Contains(searchString));
            }

            // Apply subject filter
            if (!string.IsNullOrEmpty(subject))
            {
                resources = resources.Where(r => r.Subject == subject);
            }

            // Apply grade level filter
            if (gradeLevel != null)
            {
                resources = resources.Where(r => r.GradeLevel == gradeLevel);
            }

            // Apply resource type filter
            if (!string.IsNullOrEmpty(resourceType))
            {
                resources = resources.Where(r => r.ResourceType == resourceType);
            }

            return View(resources.ToList());
        }
    }
}
