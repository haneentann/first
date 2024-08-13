﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using first.Model;

namespace first.Pages
{
    public class SignUpModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; }
        public string msg { get; set; } = string.Empty;

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Helper helper = new Helper();
            int n = helper.Insert(NewUser, "Users");
            if (n == -1)
            {
                msg = "Username already taken.";
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
