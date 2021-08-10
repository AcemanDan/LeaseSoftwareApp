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
    public class DetailsModel : PageModel
    {
        private readonly LeaseSoftware.Data.LeaseSoftwareContext _context;

        public DetailsModel(LeaseSoftware.Data.LeaseSoftwareContext context)
        {
            _context = context;
        }

        public Tenant Tenant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
            return Page();
        }
    }
}
