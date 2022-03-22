using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RazorPages.Models
{
    public  class Credential
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
