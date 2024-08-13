using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace first.Pages.Content
{
    public class FamilyModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Login")))
            {
                return RedirectToPage("/Content/AccessDenied");
            }
            return Page();
        }
    }
}