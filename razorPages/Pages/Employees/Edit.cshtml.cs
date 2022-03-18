using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using System.Linq;
using RazorPages.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace razorPages.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        [BindProperty]
        public Employee Employee { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }
        [BindProperty]
        public bool Notify { get; set; }
        public string Message { get; set; }
        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._employeeRepository = employeeRepository;
            this.webHostEnvironment = webHostEnvironment;
        }
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Employee = _employeeRepository.GetEmployee(id.Value);
            }
            else
            {
                Employee=new Employee();
            }
            if (Employee == null) return RedirectToPage("/NotFound");
            return Page();
        }
        public IActionResult OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            // χρησιμοποιω tempdata για να περασω δεδομενα απο την μια σελιδα στην αλλη
            TempData["message"]=Message;
            return RedirectToPage("Details", new { id = id});
        }
        public IActionResult OnPost(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    //περνουμε το path απο την ηδη υπαρχον φωτο στον φακελο images και την διαγραφουμε
                    if (employee.PhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                        System.IO.File.Delete(filePath);
                    }

                    //δινουμε το path της καινουργιας φωτογραφιας
                    employee.PhotoPath = ProcessUploadedFile();
                }
                if(employee.Id != 0) _employeeRepository.Update(employee);
                else _employeeRepository.Add(employee);


                return RedirectToPage("Index");
            }
            return Page();
        }

        // μεθοδος για το upload της φωτογραφιας και την αποθηκευση της στο images
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
