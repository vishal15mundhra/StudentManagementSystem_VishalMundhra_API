using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem_VishalMundhra_API.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem_VishalMundhra_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/classes
        [HttpGet]
        public ActionResult<IEnumerable<Class>> GetClasses()
        {
            return _context.Classes.ToList();
        }

        // POST: api/classes/import
        [HttpPost("import")]
        public IActionResult ImportClasses([FromForm] IFormFile file)
        {
            // Check file size
            if (file.Length > 5 * 1024 * 1024) // 5 MB
            {
                return BadRequest("File size exceeds the limit (5 MB).");
            }

            try
            {
                // Process CSV file and import classes
                // Example: read CSV file, parse data, and insert classes into the database
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return Ok("Classes imported successfully.");
        }
    }
}
