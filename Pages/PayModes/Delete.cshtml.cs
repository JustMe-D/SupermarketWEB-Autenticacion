using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SupermarketWEB.Data;
using SupermarketWEB.Models;

namespace SupermarketWEB.Pages.PayModes
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly SupermarketContext _context;
        public DeleteModel(SupermarketContext context)
        {
            _context = context;
        }
        [BindProperty]
        public PayMode PayMode { get; set; } = default!;
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PayModes == null)
            {
                return NotFound();
            }

            var paymode = await _context.PayModes.FirstOrDefaultAsync(m => m.Id == id);
            if (paymode == null)
            {
                return NotFound();
            }
            else
            {
                PayMode = paymode;
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.PayModes == null)    
            {
                return NotFound();
            }
            var paymode = await _context.PayModes.FindAsync(id);
            if (paymode != null)
            {
                PayMode = paymode;
                _context.PayModes.Remove(PayMode);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
