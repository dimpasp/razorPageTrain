using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPages.Models
{
    public class Project
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Name is required"),
            MinLength(3, ErrorMessage = "Name must have at least 3 characters")]
        public string Tittle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime DateCreated { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public Dept? Department { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EmployeeName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Project()
        {
            DateCreated = DateTime.Today;
        }
    }
}
