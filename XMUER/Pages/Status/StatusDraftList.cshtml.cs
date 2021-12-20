using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XMUER.Mapper.Base;

namespace XMUER.Pages.Status
{
    public class StatusDraftListModel : PageModel
    {
        private readonly MyContext _db;
        public List<Models.Home.Status> statuses { get; set; }
        private int userId { get; set; }

        public StatusDraftListModel(MyContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            string tmp = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(tmp))
            {
                return Redirect("/SignIn");
            }
            userId = Convert.ToInt32(tmp);
            statuses = _db.Statuses.Where(s => s.UserID == userId).Where(s => s.State == 1)
                .ToList();

            return Page();
        }
    }
}
