using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LeaseSoftware.Data;
using LeaseSoftware.Models;

namespace LeaseSoftware.Pages.Tenants
{
    public class DeleteModel : PageModel
    {
        private readonly LeaseSoftware.Data.LeaseSoftwareContext _context;

        public DeleteModel(LeaseSoftware.Data.LeaseSoftwareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tenant Tenant { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tenant = await _context.Tenants
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Tenant == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = await _context.Tenants.FindAsync(id);

            if (tenant == null)
            {
                return NotFound();
            }

            try
            {
                _context.Tenants.Remove(tenant);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }           
        }
    }
}
