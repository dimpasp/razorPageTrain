using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPages.Models;
using RazorPages.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace razorPages.Pages.Project
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext context;
        private readonly IProjectRepository _projectepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public RazorPages.Models.Project Project { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        //public IEnumerable<Employee> displayEmployees { get; set; }
        public EditModel(IProjectRepository projectepository, IWebHostEnvironment webHostEnvironment, AppDbContext context)
        {
            this._projectepository = projectepository;
            this.webHostEnvironment = webHostEnvironment;
            this.context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
        {
            //displayEmployees = await context.Employees.ToListAsync();
            if (id.HasValue)
            {
                Project = await _projectepository.getProjectByIdAsync(id.Value);
            }
            else
            {
                Project = new RazorPages.Models.Project();
            }
            ViewData["EmployeeId"] = new SelectList(context.Employees.ToList(), "Id", "Name");
            if (Project == null) return RedirectToPage("/NotFound");
            return Page();
        }
        public async Task<IActionResult> OnPost(RazorPages.Models.Project project)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    if (project.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", project.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    project.PhotoPath = ProcessUploadedFile();
                }
                ViewData["EmployeeId"] = new SelectList(context.Employees.ToList(), "Id", "Name");
                if (project.id != 0) await _projectepository.UpdateAsync(project);
                else await _projectepository.AddAsync(project);
                return RedirectToPage("Index");
            }
            return Page();
        }    
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}

