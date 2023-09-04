using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyRazoPage.Models;
using StudyRazorPage.Models;
using X.PagedList;

namespace StudyRazorPage.Pages.Admin
{
    public class User_ListModel : PageModel
    {
        private readonly RazorPageDbContext _db;

        //bien thanh vien
        public IPagedList<AppUser> ListUsers { get; set; }    

        //lenh go tat : ctor
        public User_ListModel(RazorPageDbContext db)
        {
            _db = db;
        }
        public void OnGet([FromQuery] int page = 1)
        {
            
            ListUsers = _db.AppUsers
                .OrderByDescending(x => x.Id)
                .ToPagedList(page, 3);  
        }
    }
}
