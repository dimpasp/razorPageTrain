using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace razorPages.Pages.Acount
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; }

        private readonly ICredentialRepository _credentialRepository;

        public LoginModel(ICredentialRepository credentialRepository)
        {
            this._credentialRepository = credentialRepository;
        }
        public void OnGet()
        {
            
        }
        //public IActionResult OnPost(Credential credential)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (credential.RememberMe)
        //        {
        //            _credentialRepository.Add(credential);
        //        }             
        //        return RedirectToPage("/Index");
        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnPostAsync(Credential credential)
        {
            if (ModelState.IsValid)
            {
                if (credential.RememberMe) _credentialRepository.Add(credential);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,credential.UserName)
                };
                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("MyCookieAuth", principal);
                return RedirectToPage("/Index");
            }
            return Page();
        }
        public ActionResult Verify(Credential credential)
        {
            return Page();
        }
    }
}
