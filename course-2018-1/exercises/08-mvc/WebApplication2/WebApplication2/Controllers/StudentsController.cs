using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("Students")]
    public class StudentsController : Controller
    {
        private readonly WebApplicationContext _context;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(WebApplicationContext context, ILogger<StudentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Students
        /// <summary>
        ///  Return main page with list of Students
        /// </summary>
        [HttpGet("")]
        [SwaggerOperation(
            Summary = "Return main page with list of Students"
         )]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Show Students page");
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        /// <summary>
        /// Get details of Student with specific ID
        /// </summary>
        [HttpGet("Details/{id}")]
        [SwaggerOperation(
            Summary = "Get details of Student with specific ID"
         )]
        public async Task<IActionResult> Details(int? id)
        {
            _logger.LogInformation("Looking for student details with Id: {ID}", id);
            if (id == null)
            {
                _logger.LogWarning("Student id is null");
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                _logger.LogWarning("Student with id: {ID} not found", id);
                return NotFound();
            }
            
            return View(student);
        }

        // GET: Students/Create
        /// <summary>
        /// Create new student.
        /// </summary>
        [HttpGet("Create")]
        [SwaggerOperation(
            Summary = "Create new student"
         )]
        public IActionResult Create()
        {
            _logger.LogInformation("Create new student");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Create new Student only in case that name is not empty and group is bigger than 99 and smaller than 1001
        /// </summary>
        /// <param name="student"></param>
        [HttpPost("Create")]
        [SwaggerOperation(
            Summary = "Create new Student only in case that name is not empty and group is bigger than 99 and smaller than 1001"
         )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,group")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        /// <summary>
        /// Edit Student by ID
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("Edit/{id}")]
        [SwaggerOperation(
            Summary = "Edit Student by ID"
         )]
        public async Task<IActionResult> Edit(int? id)
        {
            _logger.LogInformation("Editing student with Id: {ID}", id);

            if (id == null)
            {
                _logger.LogWarning("Student id is null");
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                _logger.LogWarning("Student with id: {ID} not found", id);
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edit Student by ID. Will submit only in case that name is not empty and group is bigger than 99 and smaller than 1001
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost("Edit/{id}")]
        [SwaggerOperation(
            Summary = "Edit Student by ID. Will submit only in case that name is not empty and group is bigger than 99 and smaller than 1001"
         )]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,group")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        /// <summary>
        /// Delete Student by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Delete/{id}")]
        [SwaggerOperation(
            Summary = "Delete Student by ID"
         )]
        public async Task<IActionResult> Delete(int? id)
        {
            _logger.LogInformation("Deleting student with Id: {ID}", id);
            if (id == null)
            {
                _logger.LogWarning("Student id is null");
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                _logger.LogWarning("Student with id: {ID} not found", id);
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        /// <summary>
        /// Delete student by ID. Will delete only in case that Student exists.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete/{id}")]
        [SwaggerOperation(
            Summary = "Delete student by ID. Will delete only in case that Student exists."
         )]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Student.FindAsync(id);
            _context.Student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.ID == id);
        }
    }
}
