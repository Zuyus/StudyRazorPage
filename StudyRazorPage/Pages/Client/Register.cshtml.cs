using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyRazoPage.Models;
using StudyRazorPage.Common;
using StudyRazorPage.Models;

namespace StudyRazorPage.Pages.Client
{
    public class RegisterModel : PageModel
    {
        //Lien ket tren giao dien
        [BindProperty]   
        public AppUser user { get; set; }
       //get hi?n th? data
        public void OnGet()
        {


        }
        //post thêm và xoá data (Nh?n nút dk thì nó s? ch?y vào ?ây
        public ActionResult OnPost()
        {
            //check 
            if(ModelState.IsValid == false) 
            {
                return Page();
            }
            //t?o dl data
            RazorPageDbContext db = new();

            user.Role = UserRole.ROLECUSTOMER;
            user.BlockedTo = null;

            db.AppUsers.Add(user);
            db.SaveChanges();
            return Page();

        }
    }
}
