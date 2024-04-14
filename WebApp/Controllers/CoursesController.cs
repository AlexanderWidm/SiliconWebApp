using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers;

public class CoursesController(HttpClient http) : Controller
{
    private readonly HttpClient _http = http;
    private string _categoryApiUrl = "https://localhost:7266/api/categories";
    private string _courseApiUrl = "https://localhost:7266/api/courses";

    public async Task<IActionResult> Index(string category ="", string searchQuery = "", int pageNumber = 1, int pageSize = 6)
    {
        var viewModel = new CoursesViewModel();

        var categoryRespone = await _http.GetAsync(_categoryApiUrl);
        if (categoryRespone.IsSuccessStatusCode)
        {
            var categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(await categoryRespone.Content.ReadAsStringAsync());
            if (categories != null)
                viewModel.Categories = categories;

        }
        var courseResponse = await _http.GetAsync($"{_courseApiUrl}?category={Uri.EscapeDataString(category)}&searchQuery={Uri.EscapeDataString(searchQuery)}&pageNumber={pageNumber}&pageSize={pageSize}");
        if (courseResponse.IsSuccessStatusCode)
        {
            var result = JsonConvert.DeserializeObject<CourseResult>(await courseResponse.Content.ReadAsStringAsync());
            if (result != null)
            {
                viewModel.Courses = result.Courses;
                viewModel.Pagination = new Pagination
                {
                    PageSize = pageSize,
                    CurrentPage = pageNumber,
                    TotalPages = result.TotalPages,
                    TotalCount = result.TotalItems
                };

            }
                

        }

        return View(viewModel);
    }

    public async Task<IActionResult> Course(string id)
    {
        var response = await _http.GetAsync($"{_courseApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            var course = JsonConvert.DeserializeObject<Course>(await response.Content.ReadAsStringAsync());
            if (course != null)
            {
                var viewModel = new CourseViewModel
                {
                    Course = course
                };
                return View(viewModel);
            }
            else
            {
                return NotFound("Course not found");
            }
        }
        else
        {
            return BadRequest("Error fetching course details");
        }
    }

}
    