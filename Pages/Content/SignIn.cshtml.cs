using first.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace first.Pages
{
    public class SignInModel : PageModel
    {
        //@haneen
        public string msg { get; set; } = string.Empty;

        [BindProperty]
        public string Username { get; set; } = string.Empty;
        [BindProperty]
        public string password { get; set; } = string.Empty;

        public void OnGet()

        {
        }
        //@haneen
        public IActionResult OnPost(string Username, string password)
        {
           
            string SQLStr = $"SELECT * FROM Users WHERE Username LIKE '{Username}' AND Password LIKE '{password}'";
            Helper helper = new Helper();
            DataTable dt = helper.RetrieveTable(SQLStr, "Users");

            
            if (dt.Rows.Count > 0)
            {
                HttpContext.Session.SetString("Login", Username);
                HttpContext.Session.SetString("Admin", dt.Rows[0]["UserAdmin"].ToString());
                // Check if the user is an admin
                bool isAdmin = Convert.ToBoolean(dt.Rows[0]["UserAdmin"]);
                // Redirect based on the admin status
                if (isAdmin)
                {
                    return RedirectToPage("../Users/Index"); // Redirect to users/index.html if admin
                }
                else
                {
                    return RedirectToPage("/Content/Family"); // Redirect to Index.html if not admin
                }

            }


            msg = "Wrong username or password.";
            return Page();
            
        }
     
    }
}
