using System;
using System.Collections.Generic;
using System.Text;

namespace RazorPages.Models
{
    public class Employee
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhotoPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Dept? Department { get; set; }
    }
}
