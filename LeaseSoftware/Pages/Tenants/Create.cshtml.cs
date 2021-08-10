using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LeaseSoftware.Data;
using LeaseSoftware.Models;

namespace LeaseSoftware.Pages.Tenants
{
    public class CreateModel : PageModel
    {
        private readonly LeaseSoftware.Data.LeaseSoftwareContext _context;

        public CreateModel(LeaseSoftware.Data.LeaseSoftwareContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tenant Tenant { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyTenant = new Tenant();

            if (await TryUpdateModelAsync<Tenant>(
                emptyTenant,
                "tenant",
                t => t.LastName, t => t.FirstName, t => t.Email,
                t => t.Phone, t => t.Company, t => t.BusinessPhone))
            {
                _context.Tenants.Add(emptyTenant);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
