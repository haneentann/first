using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using first.Model;
using System.Data;

namespace first.Pages.Content
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public User NewUser { get; set; } = new User();
        public string msg { get; set; } = string.Empty;

        public IActionResult OnGet(string param)
        {
            int id = int.Parse(param);
            Helper helper = new Helper();
            string SQL = $"SELECT * FROM Users WHERE Id = {id}";

            NewUser = new User();
            
            DataTable dt = helper.RetrieveTable(SQL, "Users");
            DataRow dr = dt.Rows[0];

            NewUser.ID = id;
            NewUser.Username = dr["Username"].ToString();
            NewUser.Password = dr["Password"].ToString();
            NewUser.FirstName = dr["FirstName"].ToString();
            NewUser.LastName = dr["LastName"].ToString();
            NewUser.Email = dr["Email"].ToString();
            NewUser.Phone = dr["Phone"].ToString();
            NewUser.Gender = dr["Gender"].ToString();
            NewUser.City = dr["City"].ToString();
            NewUser.UserAdmin = (bool)dr["UserAdmin"];
            NewUser.DateOfBirth = DateTime.Parse(dr["DateOfBirth"].ToString());


            return Page();


        }
        public IActionResult OnPost()
        {
            Helper helper = new Helper();
            try
            {
                int n = helper.Update(NewUser, "Users");
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return Page();
            }
            return RedirectToPage("Index");
        }
    }
}
