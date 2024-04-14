using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController(CourseContext context) : ControllerBase
{
    private readonly CourseContext _context = context;

    [HttpGet]
    public async Task<IActionResult> GetAll(string category = "", string searchQuery = "", int pageNumber = 1, int pageSize = 10)
    {
        var query = _context.Courses
            .Include(i => i.Category)
            .AsQueryable();

        if (!string.IsNullOrEmpty(searchQuery))
            query = query.Where(x => x.Title.Contains(searchQuery) || x.Author.Contains(searchQuery));

        if (!string.IsNullOrEmpty(category) && category != "all")
            query = query.Where(x => x.Category!.CategoryName == category);

        query = query.OrderByDescending(o => o.LastUpdated);

        var totalItemCount = await query.CountAsync();
        var totalPages = (int)Math.Ceiling(totalItemCount / (double)pageSize);
        var courses = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

        var result = new CourseResult
        {
            TotalItems = totalItemCount,
            TotalPages = totalPages,
            Courses = CourseFactory.Create(courses),
        };

        return Ok(result);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(string id)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }
}
