using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly SupermarketContext _context;

        public CreateModel(SupermarketContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public User User { get; set; } = default!;
        public List<SelectListItem> RoleOptions { get; } = new()
    {
        new SelectListItem { Value = "User", Text = "User" },
        new SelectListItem { Value = "Admin", Text = "Admin" }
    };
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Users == null || User == null)
            {
                return Page();
            }
            _context.Users.Add(User);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }


    }
}
