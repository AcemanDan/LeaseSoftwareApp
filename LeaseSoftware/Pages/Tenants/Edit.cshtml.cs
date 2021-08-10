using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaseSoftware.Data;
using LeaseSoftware.Models;

namespace LeaseSoftware.Pages.Tenants
{
    public class EditModel : PageModel
    {
        private readonly LeaseSoftware.Data.LeaseSoftwareContext _context;

        public EditModel(LeaseSoftware.Data.LeaseSoftwareContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tenant Tenant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Tenant = await _context.Tenants.FirstOrDefaultAsync(m => m.Id == id);
            Tenant = await _context.Tenants.FindAsync(id);

            if (Tenant == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var tenantToUpdate = await _context.Tenants.FindAsync(id);

            if (tenantToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Tenant>(
                tenantToUpdate,
                "tenant",
                t => t.LastName, t => t.FirstName, t => t.Email,
                t => t.Phone, t => t.Company, t => t.BusinessPhone))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();        
        }
    }
}
