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
        public ActionResult OnPost([FromServices] RazorPageDbContext db)
        {
            //check 
            if(ModelState.IsValid == false) 
            {
                return Page();
            }

            //Chuẩn hóa username và email
            user.Username = user.Username.ToLower().Trim();
            user.Email = user.Email.ToLower().Trim();
            
            //Check username và email đã tồn tại chưa ?
            var exists = db.AppUsers.Any(u => u.Email == user.Email || u.Username == user.Username) ;
            if (exists) 
            {
                ModelState.AddModelError("", "Email hoặc tên đăng nhập đã được sử dụng!");
                return Page();
            }

            //Hash mật khẩu
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password); 
            //tạo dl data
      
            user.Role = UserRole.ROLECUSTOMER;
            user.BlockedTo = null;

            db.AppUsers.Add(user);
            db.SaveChanges();
            return Page();

        }
    }
}
